using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Post_Eventos_Vfinal.Data;
using Api_Post_Eventos_Vfinal.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Api_Post_Eventos_Vfinal.Controllers
{
    [Controller]

    
    public class PostFeedController : Controller
    {
        private readonly MyDbContext _context;

        public PostFeedController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var postFeeds = await _context.PostFeed.Include(pf => pf.post).ToListAsync();
            return View(postFeeds);
        }

        // GET: api/PostFeed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post_Feed>>> GetPostFeeds()
        {
            return await _context.PostFeed.Include(pf => pf.post).ToListAsync();
        }

        // GET: api/PostFeed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post_Feed>> GetPostFeed(int id)
        {
            var postFeed = await _context.PostFeed.Include(pf => pf.post).FirstOrDefaultAsync(pf => pf.IDdePost == id);

            if (postFeed == null)
            {
                return NotFound();
            }

            return postFeed;
        }

        // POST: api/PostFeed
        [HttpPost]
        public async Task<ActionResult<Post_Feed>> CreatePostFeed(Post_Feed postFeed)
        {
            // Check if the referenced Post exists
            if (!await _context.Post.AnyAsync(p => p.ID == postFeed.IDdePost))
            {
                return BadRequest("Invalid Post ID");
            }

            _context.PostFeed.Add(postFeed);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostFeed), new { id = postFeed.IDdePost }, postFeed);
        }

        // PUT: api/PostFeed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostFeed(int id, Post_Feed postFeed)
        {
            if (id != postFeed.IDdePost)
            {
                return BadRequest();
            }

            _context.Entry(postFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostFeedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PostFeed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostFeed(int id)
        {
            var postFeed = await _context.PostFeed.FindAsync(id);
            if (postFeed == null)
            {
                return NotFound();
            }

            _context.PostFeed.Remove(postFeed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostFeedExists(int id)
        {
            return _context.PostFeed.Any(e => e.IDdePost == id);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Posts = await _context.Post.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post_Feed postFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Posts = await _context.Post.ToListAsync();
            return View(postFeed);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postFeed = await _context.PostFeed.FindAsync(id);
            if (postFeed == null)
            {
                return NotFound();
            }
            ViewBag.Posts = await _context.Post.ToListAsync();
            return View(postFeed);
        }


    }
}
