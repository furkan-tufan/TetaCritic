using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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



        public async Task<IActionResult> FilmSayfasiAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmler
                .Include(f => f.Ktg)
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }

            ViewBag.FilmId = id;
            var comments = _context.Yorum.Where(d => d.FilmId.Equals(id.Value)).ToList();
            ViewBag.Comments = comments;

            var ratings = _context.Yorum.Where(d => d.FilmId.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Derece.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(film);
        }

        public IActionResult Anasayfa()
        {
            return View();
        }
    }
}
