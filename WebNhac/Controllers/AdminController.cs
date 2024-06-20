using Microsoft.AspNetCore.Mvc;
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
            var viewModel = new AdminViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> QLDanhmuc()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> QLMV()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> QLNguoidung()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new AdminViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}
