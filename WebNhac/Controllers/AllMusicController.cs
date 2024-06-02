using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class AllMusicController : Controller
    {
        private readonly WebNhacContext _context;

        public AllMusicController(WebNhacContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var musics = await _context.Musics.OrderByDescending(m => m.IdMusic).ToListAsync();
            var viewModel = new AllMusicViewModel
            {
                Menus = menus,
                Musics = musics,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}
