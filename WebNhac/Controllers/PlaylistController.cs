using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly WebNhacContext _context;

        public PlaylistController(WebNhacContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var playlists = await _context.AdminPlayLists.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new PlaylistViewModel
            {
                Menus = menus,
                PlaylistMusic = playlists,
            };
            return View(viewModel);
        }
    }
}
