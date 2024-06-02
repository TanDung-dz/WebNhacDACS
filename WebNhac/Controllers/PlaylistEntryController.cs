using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class PlaylistEntryController : Controller
    {
        private readonly WebNhacContext _context;

        public PlaylistEntryController(WebNhacContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> Index(string slug, long id)
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var list_music = await _context.AdminPlayListEntries.Where(m => m.IdPlaylist == id && m.Link == slug).ToListAsync();
            var musics = new List<Music>();
            foreach (var item in list_music)
            {
                var tmp = await _context.Musics.Where(m => m.IdMusic == item.IdMusic).FirstOrDefaultAsync();
                musics.Add(tmp);
            }
            var viewModel = new PlaylistEntryViewModel
            {
                Menus = menus,
                Musics = musics,
            };
            return View(viewModel);
        }
    }
}
