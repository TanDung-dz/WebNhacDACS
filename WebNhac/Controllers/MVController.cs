using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNhac.Models;
using WebNhac.ViewModels;

namespace WebNhac.Controllers
{
    public class MVController : Controller
    {
        private readonly WebNhacContext _context;
        public MVController(WebNhacContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string slug, long id)
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var mvs = await _context.Mvs.Where(m => m.IdMv == id && m.Link == slug).ToListAsync();
            var mv =  await _context.Mvs.Where(m => m.IdMv == id).FirstOrDefaultAsync();
            var mvkhac = await _context.Mvs.Where(m => m.IdMv != id && m.Link != slug).OrderBy(m => m.Order).ToListAsync();
            Random rd = new Random();
            foreach (var item in mvkhac)
            {
                item.Order = rd.Next(1, mvkhac.Count+1);
            }
            var randommvs = mvkhac.OrderBy(m => m.Order).ToList();
            // cập nhật lượt xem cho mv
            mv.CountView += 1;
            _context.SaveChanges();
            var viewModel = new MVViewModel
            {
                Menus = menus,
                Mvs = mvs,
                randomMvs = randommvs,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }

    }
}
