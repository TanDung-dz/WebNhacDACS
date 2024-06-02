using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class RankController : Controller
    {
        private readonly WebNhacContext _context;

        public RankController(WebNhacContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var musics = await _context.Musics.OrderByDescending(m => m.CountListened).Take(18).ToListAsync();
            var viewModel = new RankViewModel
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
