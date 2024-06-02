using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class UserController : Controller
    {
        private readonly WebNhacContext _context;
        public UserController(WebNhacContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m =>m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m =>m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Register = model.Register,
            };
            if (model.Register != null)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                    return View(viewModel);
                }
                model.Register.Password =BCrypt.Net.BCrypt.HashPassword(model.Register.Password);
                model.Register.Hide = false;
                model.Register.Permission = 0;
                _context.Users.Add(model.Register);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "User");
            }
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m =>m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m =>m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Register = model.Register,
            };
            if (model.Register != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                
                if(user !=null)
                {
                    if (BCrypt.Net.BCrypt.Verify(model.Register.Password, user.Password))
                    {
                        var claims = new List<Claim>
                    {
                       new Claim(ClaimTypes.Name, user.Username),
                       new Claim(ClaimTypes.Role, user.Permission.ToString()),
                    };
                        var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                        };
                        await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                        return RedirectToAction("Index", "Home",user);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                        return View(viewModel);
                    }
                }
                else if (admin != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(model.Register.Password, admin.Password))
                    {
                        var claims = new List<Claim>
                    {
                       new Claim(ClaimTypes.Name, admin.Username),
                       new Claim(ClaimTypes.Role, admin.Permission.ToString()),
                    };
                        var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                        };
                        await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                        return View(viewModel);
                    }
                }
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Info()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m =>m.Order).ToListAsync();
            
            var users = new User();
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                if (username != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.Username == username);
                }
            }
            var ls = await _context.Histories.Where(m => m.IdUser == users.IdUser).OrderByDescending(m => m.IdHistory).ToListAsync();
            var listmusic = new List<Music>();
            foreach(var item in ls)
            {
                var song = await _context.Musics.Where(m => m.Hide == false && m.IdMusic == item.IdMusic).FirstOrDefaultAsync();
                listmusic.Add(song);

            }
            var listsinger = new List<Singer>();
            foreach (var item in listmusic)
            {
                var singer = await _context.Singers.Where(m => m.Hide == false && m.IdSinger == item.IdSinger).FirstOrDefaultAsync();
                listsinger.Add(singer);
            }
            // lấy ngày nghe trong lịch sử
            var listDate = new List<DateTime>();
            foreach(var item in ls)
            {
                var date = (DateTime)item.ListenedDate;
                listDate.Add(date);
            }
                var viewModel = new UserViewModel
            {
                Menus = menus,
                Register = users,
                historyMusic = listmusic,
                History = ls,
                singerMusic = listsinger,
                historyDate = listDate,
            };       
            return View(viewModel);
        }
        //xoa lic su nghe nhac
        [HttpPost]
        public async Task<IActionResult> DeleteHistory(int historyId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var history = await _context.Histories.FirstOrDefaultAsync(h => h.IdHistory == historyId);
                if (history != null)
                {
                    _context.Histories.Remove(history);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Info)); // Điều hướng lại trang Info sau khi xóa
                }
            }
            return BadRequest("Không thể xóa lịch sử.");
        }


        public async Task<IActionResult> EditInfo()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var users = new User();
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                if (username != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.Username == username);
                }
            }
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Register = users,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInfo(UserViewModel model)
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Register = model.Register,
            };
            if (model.Register != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                user.Name=model.Register.Name;
                user.Email= model.Register.Email;
                user.Phone = model.Register.Phone;
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Register.Password);
                user.Hide = false;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "User");
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}
