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
    public class TBooksController : Controller
    {
        private readonly LibraryContext _context;

        public TBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TBooks
        public async Task<IActionResult> Index()
        {
              return View(await _context.TBooks.ToListAsync());
        }

        // GET: TBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBooks == null)
            {
                return NotFound();
            }

            var tBook = await _context.TBooks
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tBook == null)
            {
                return NotFound();
            }

            return View(tBook);
        }

        // GET: TBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,BookPageCount,AuthorId")] TBook tBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBook);
        }

        // GET: TBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBooks == null)
            {
                return NotFound();
            }

            var tBook = await _context.TBooks.FindAsync(id);
            if (tBook == null)
            {
                return NotFound();
            }
            return View(tBook);
        }

        // POST: TBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,BookPageCount,AuthorId")] TBook tBook)
        {
            if (id != tBook.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBookExists(tBook.BookId))
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
            return View(tBook);
        }

        // GET: TBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBooks == null)
            {
                return NotFound();
            }

            var tBook = await _context.TBooks
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tBook == null)
            {
                return NotFound();
            }

            return View(tBook);
        }

        // POST: TBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBooks == null)
            {
                return Problem("Entity set 'LibraryContext.TBooks'  is null.");
            }
            var tBook = await _context.TBooks.FindAsync(id);
            if (tBook != null)
            {
                _context.TBooks.Remove(tBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBookExists(int id)
        {
          return _context.TBooks.Any(e => e.BookId == id);
        }
    }
}
