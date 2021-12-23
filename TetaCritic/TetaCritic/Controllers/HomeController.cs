using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TetaCritic.Models;

namespace TetaCritic.Controllers
{
    public class HomeController : Controller
    {
        private readonly TetaCriticContext _context;

        public HomeController(TetaCriticContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> KategoriMenusu(int? id)
        {
            var kategori = await _context.Kategoriler.Include(m => m.FilmListesi)
                .FirstOrDefaultAsync(m => m.KategoriId == id);
            ViewData["Filmler"] = _context.Filmler.ToList();

            ViewData["Kategoriler"] = _context.Kategoriler.ToList();
            return View(kategori);
        }


        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
