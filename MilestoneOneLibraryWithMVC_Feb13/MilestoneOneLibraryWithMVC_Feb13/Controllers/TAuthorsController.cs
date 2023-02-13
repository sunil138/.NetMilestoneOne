using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilestoneOneLibraryWithMVC_Feb13.Models;

namespace MilestoneOneLibraryWithMVC_Feb13.Controllers
{
    public class TAuthorsController : Controller
    {
        private readonly LibraryContext _context;

        public TAuthorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TAuthors
        public async Task<IActionResult> Index()
        {
              return View(await _context.TAuthors.ToListAsync());
        }

        // GET: TAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TAuthors == null)
            {
                return NotFound();
            }

            var tAuthor = await _context.TAuthors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tAuthor == null)
            {
                return NotFound();
            }

            return View(tAuthor);
        }

        // GET: TAuthors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName,AuthorSurname")] TAuthor tAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tAuthor);
        }

        // GET: TAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TAuthors == null)
            {
                return NotFound();
            }

            var tAuthor = await _context.TAuthors.FindAsync(id);
            if (tAuthor == null)
            {
                return NotFound();
            }
            return View(tAuthor);
        }

        // POST: TAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName,AuthorSurname")] TAuthor tAuthor)
        {
            if (id != tAuthor.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TAuthorExists(tAuthor.AuthorId))
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
            return View(tAuthor);
        }

        // GET: TAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TAuthors == null)
            {
                return NotFound();
            }

            var tAuthor = await _context.TAuthors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tAuthor == null)
            {
                return NotFound();
            }

            return View(tAuthor);
        }

        // POST: TAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TAuthors == null)
            {
                return Problem("Entity set 'LibraryContext.TAuthors'  is null.");
            }
            var tAuthor = await _context.TAuthors.FindAsync(id);
            if (tAuthor != null)
            {
                _context.TAuthors.Remove(tAuthor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAuthorExists(int id)
        {
          return _context.TAuthors.Any(e => e.AuthorId == id);
        }
    }
}
