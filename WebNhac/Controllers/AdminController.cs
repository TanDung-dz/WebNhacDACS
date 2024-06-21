using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class AdminController : Controller
    {
        private readonly WebNhacContext _context;

        public AdminController(WebNhacContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> QLNhac()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var musics = await _context.Musics.ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
                Musics = musics,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> QLDanhmuc()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var types = await _context.MusicTypes.ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
                MusicTypes = types,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> QLMV()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var mv = await _context.Mvs.ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
                mvs = mv,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> QLNguoidung()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var users = await _context.Users.ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
                Users = users,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> AddMusic()
        {
            var types = _context.MusicTypes.ToList();
            var singers = _context.Singers.ToList();
            var authors = _context.Authors.ToList();
            ViewBag.Musictype = new SelectList(types, "IdMusictype", "Name");
            ViewBag.Singer = new SelectList(singers, "IdSinger", "Name");
            ViewBag.Author = new SelectList(authors, "IdAuthor", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMusic(Music music)
        {
            if (ModelState.IsValid)
            {
                music.IdAdmin = 1;
                music.PublishDate = DateTime.Now;
                music.Hide=false;
                music.CountListened = 0;
                _context.Musics.Add(music);
                _context.SaveChanges();
                return RedirectToAction("QLNhac");
            }
            var types = _context.MusicTypes.ToList();
            var singers = _context.Singers.ToList();
            var authors = _context.Authors.ToList();
            ViewBag.Musictype = new SelectList(types, "IdMusictype", "Name");
            ViewBag.Singer = new SelectList(singers, "IdSinger", "Name");
            ViewBag.Author = new SelectList(authors, "IdAuthor", "Name");
            return View(music); 
        }
    }
}
