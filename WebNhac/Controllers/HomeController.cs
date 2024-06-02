using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Linq;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebNhacContext _context;

        public HomeController(WebNhacContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var sliders = await _context.SlideShows.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();

            // var mvhot = await _context.Mvs.Where(m => m.Hide == false).OrderBy(m => m.CountView).ToArrayAsync();
            
            var mvhot = await _context.Mvs.Where(m => m.Hide == false).OrderByDescending(m => m.PublishDate).Take(6).ToListAsync();

            var nhacviet = await _context.Musics.Where(m => m.Hide == false && m.IdMusictype == 1).OrderBy(m => m.CountListened).Take(4).ToListAsync();
            var nhackpop = await _context.Musics.Where(m => m.Hide == false && m.IdMusictype == 2 ).OrderBy(m => m.CountListened).Take(4).ToListAsync();
            var nhacaumy = await _context.Musics.Where(m => m.Hide == false && m.IdMusictype == 3).OrderBy(m => m.CountListened).Take(4).ToListAsync();
            var nhacchill = await _context.Musics.Where(m => m.Hide == false && m.IdMusictype == 4).OrderBy(m => m.CountListened).Take(4).ToListAsync();

            var bxh = await _context.Musics.Where(m => m.Hide == false).OrderByDescending(m => m.CountListened).Take(8).ToListAsync();
            var singerBxh = new List<Singer>();
            foreach(var item in bxh)
            {
                var singer = await _context.Singers.Where(m => m.Hide == false && m.IdSinger == item.IdSinger).FirstOrDefaultAsync();
                singerBxh.Add(singer);
            }
            var viewModel = new HomeViewModel
            {
                Menus = menus,
                Sliders = sliders,
                MV = mvhot,
                NhacViet = nhacviet,
                NhacKpop = nhackpop,
                NhacAuMy = nhacaumy,
                Nhacchill = nhacchill,
                BXH = bxh,
                bxhSinger = singerBxh,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> _SlidePartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _NhacVietPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> _NhacKpopPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> _NhacAuMyPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> _NhacchillMyPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> _MVPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _BXHPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> Baihat()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();

            var viewModel = new HomeViewModel
            {
                Menus = menus,
                
            };
            return View(viewModel);
        }
        
    }
}
