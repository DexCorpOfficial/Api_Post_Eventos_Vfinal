using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Api_Post_Eventos_Vfinal.Data;
using Api_Post_Eventos_Vfinal.Models;

namespace Api_Post_Eventos_Vfinal.Controllers
{
    public class Post_BandaController : Controller
    {
        private readonly MyDbContext _context;

        public Post_BandaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Post_Banda
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostBanda.ToListAsync());
        }

        // GET: Post_Banda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post_Banda = await _context.PostBanda
                .FirstOrDefaultAsync(m => m.IDdePost == id);
            if (post_Banda == null)
            {
                return NotFound();
            }

            return View(post_Banda);
        }

        // GET: Post_Banda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post_Banda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDdeCuenta,IDdeBanda,ID,media,descripcion,fecha_pub,activo")] Post_Banda post_Banda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post_Banda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post_Banda);
        }

        // GET: Post_Banda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post_Banda = await _context.PostBanda.FindAsync(id);
            if (post_Banda == null)
            {
                return NotFound();
            }
            return View(post_Banda);
        }

        // POST: Post_Banda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDdeCuenta,IDdeBanda,ID,media,descripcion,fecha_pub,activo")] Post_Banda post_Banda)
        {
            if (id != post_Banda.IDdePost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post_Banda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Post_BandaExists(post_Banda.IDdePost))
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
            return View(post_Banda);
        }

        // GET: Post_Banda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post_Banda = await _context.PostBanda
                .FirstOrDefaultAsync(m => m.IDdePost == id);
            if (post_Banda == null)
            {
                return NotFound();
            }

            return View(post_Banda);
        }

        // POST: Post_Banda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post_Banda = await _context.PostBanda.FindAsync(id);
            _context.PostBanda.Remove(post_Banda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Post_BandaExists(int id)
        {
            return _context.PostBanda.Any(e => e.IDdePost == id);
        }
    }
}
