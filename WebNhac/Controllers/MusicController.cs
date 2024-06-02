using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.WebSockets;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class MusicController : Controller
    {
        private readonly WebNhacContext _context;

        public MusicController(WebNhacContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string slug, long id)
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            
            var musics = await _context.Musics.Where(m => m.IdMusic == id && m.Link == slug).ToListAsync();
            
            var song = await _context.Musics.Where(m => m.IdMusic == id && m.Link == slug).FirstOrDefaultAsync();
            //tang lượt nghe bai hat 
            song.CountListened += 1;
            _context.SaveChanges();
            // danh sách bài hát nghe tiếp
            var randommusics = await _context.Musics.Where(m => m.IdMusic != id && m.Link != slug && m.IdSinger == song.IdSinger).OrderBy(m => m.Order).ToListAsync();
            var author = await _context.Authors.FirstOrDefaultAsync(m => m.IdAuthor == song.IdAuthor);
            /// cập nhật lịch sử nghe của user
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                if (username != null)
                {
                    
                    var user = await _context.Users.FirstOrDefaultAsync(m => m.Username == username);
                    // random bài hát trừ bài đã nghe ra (trừ ra 5 bài nghe gần nhất) với điều kiện user đã đăng nhập
                    var ls = await _context.Histories.Where(m => m.IdUser == user.IdUser).Take(3).ToListAsync();
                    // cập nhật lại danh sách bài hát nghe tiếp
                    var toRemove = new List<Music>();
                    foreach (var item in randommusics)
                    {
                        foreach (var item2 in ls)
                        {
                            if(item.IdMusic == item2.IdMusic)
                            {
                                toRemove.Add(item);
                            }
                        }
                    }
                    foreach(var item in toRemove)
                    {
                        randommusics.Remove(item);
                    }
                    // danh sách nghe tiếp sẽ load lên 7 bài. Các câu lệnh sau sẽ kiểm tra xem danh sách nhạc nghe tiếp theo nghệ sĩ 
                    // có bao nhiêu bài. Nếu ít hơn 7 bài thì sẽ lấy các bài hát khác của ca sĩ khác thêm vào.
                    if(randommusics.Count<7)
                    {
                        // lấy số bài hát còn lại
                        int conlai = 7 - randommusics.Count;
                        var randomaddition = await _context.Musics.Where(m => m.IdSinger != song.IdSinger).Take(conlai).ToListAsync();
                        // random lại danh sách thêm vào
                        randommusics.AddRange(randomaddition);
                        Random rd = new Random();
                        foreach (var item in randommusics)
                        {
                            item.Order = rd.Next(1, randommusics.Count + 1);
                        }
                        randommusics.OrderBy(m => m.Order).ToList();
                    }
                    //Kiểm tra lịch sử user đã nghe bài hát chưa
                    var ktls = await _context.Histories.FirstOrDefaultAsync(m => m.IdMusic == song.IdMusic && m.IdUser == user.IdUser);
                    if(ktls != null)//nếu có thì xóa đi
                    {
                        _context.Histories.Remove(ktls);
                        _context.SaveChanges();
                    }
                    var history = new History()
                    {

                        IdUser = user.IdUser,
                        IdMusic = song.IdMusic,
                        ListenedDate = DateTime.Now,
                        

                    };
                    _context.Histories.Add(history);
                    _context.SaveChanges();
                }
            }
            ///hiện tên nghệ sĩ trong danh sách nghe tiếp
            var singerrandom = new List<Singer>();
            foreach(var item in randommusics)
            {
                var singer = await _context.Singers.Where(m => m.IdSinger == item.IdSinger).FirstOrDefaultAsync();
                singerrandom.Add(singer);
            }
            var viewModel = new MusicViewModel
            {
                Menus = menus,
                Musics = musics,
                randomMusics = randommusics,
                Author = author,
                singerRandom = singerrandom,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}
