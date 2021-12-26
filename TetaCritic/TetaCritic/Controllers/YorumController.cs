using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TetaCritic.Models;

namespace TetaCritic.Controllers
{
    public class YorumController : Controller
    {
        private readonly TetaCriticContext _context;

        public YorumController(TetaCriticContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Yorum.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection form)
        {
            var comment = form["Yorum"].ToString();
            var filmId = int.Parse(form["FilmId"]);
            var rating = int.Parse(form["Derece"]);

            Yorum yorum = new Yorum()
            {
                FilmId = filmId,
                Icerik = comment,
                Derece = rating,
                Zaman = DateTime.Now
            };

            _context.Yorum.Add(yorum);
            _context.SaveChanges();

            return RedirectToAction("FilmSayfasi", "Home", new { id = filmId });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YorumId,Icerik,Zaman,FilmId,Derece")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yorum);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            return View(yorum);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YorumId,Icerik,Zaman,FilmId,Derece")] Yorum yorum)
        {
            if (id != yorum.YorumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.YorumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(yorum);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yorum = await _context.Yorum.FindAsync(id);
            _context.Yorum.Remove(yorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumExists(int id)
        {
            return _context.Yorum.Any(e => e.YorumId == id);
        }
    }
}
