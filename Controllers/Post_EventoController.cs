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
    public class Post_EventoController : Controller
    {
        private readonly MyDbContext _context;

        public Post_EventoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Post_Evento
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.PostEvento.Include(p => p.evento);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Post_Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post_Evento = await _context.PostEvento
                .Include(p => p.evento)
                .FirstOrDefaultAsync(m => m.IDdePost == id);
            if (post_Evento == null)
            {
                return NotFound();
            }

            return View(post_Evento);
        }

        // GET: Post_Evento/Create
        public IActionResult Create()
        {
            ViewData["IDdeEvento"] = new SelectList(_context.Evento, "ID", "ID");
            return View();
        }

        // POST: Post_Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDdeCuenta,IDdeEvento,ID,media,descripcion,fecha_pub,activo")] Post_Evento post_Evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post_Evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDdeEvento"] = new SelectList(_context.Evento, "ID", "ID", post_Evento.IDdeEvento);
            return View(post_Evento);
        }

        // GET: Post_Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post_Evento = await _context.PostEvento.FindAsync(id);
            if (post_Evento == null)
            {
                return NotFound();
            }
            ViewData["IDdeEvento"] = new SelectList(_context.Evento, "ID", "ID", post_Evento.IDdeEvento);
            return View(post_Evento);
        }

        // POST: Post_Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDdeCuenta,IDdeEvento,ID,media,descripcion,fecha_pub,activo")] Post_Evento post_Evento)
        {
            if (id != post_Evento.IDdePost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post_Evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Post_EventoExists(post_Evento.IDdePost))
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
            ViewData["IDdeEvento"] = new SelectList(_context.Evento, "ID", "ID", post_Evento.IDdeEvento);
            return View(post_Evento);
        }

        // GET: Post_Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post_Evento = await _context.PostEvento
                .Include(p => p.evento)
                .FirstOrDefaultAsync(m => m.IDdePost == id);
            if (post_Evento == null)
            {
                return NotFound();
            }

            return View(post_Evento);
        }

        // POST: Post_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post_Evento = await _context.PostEvento.FindAsync(id);
            _context.PostEvento.Remove(post_Evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Post_EventoExists(int id)
        {
            return _context.PostEvento.Any(e => e.IDdePost == id);
        }
    }
}
