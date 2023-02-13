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
    public class TBorrowsController : Controller
    {
        private readonly LibraryContext _context;

        public TBorrowsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TBorrows
        public async Task<IActionResult> Index()
        {
              return View(await _context.TBorrows.ToListAsync());
        }

        // GET: TBorrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBorrows == null)
            {
                return NotFound();
            }

            var tBorrow = await _context.TBorrows
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (tBorrow == null)
            {
                return NotFound();
            }

            return View(tBorrow);
        }

        // GET: TBorrows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBorrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowId,TakenDate,ReturnDate,BookId,StudentId")] TBorrow tBorrow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBorrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBorrow);
        }

        // GET: TBorrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBorrows == null)
            {
                return NotFound();
            }

            var tBorrow = await _context.TBorrows.FindAsync(id);
            if (tBorrow == null)
            {
                return NotFound();
            }
            return View(tBorrow);
        }

        // POST: TBorrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,TakenDate,ReturnDate,BookId,StudentId")] TBorrow tBorrow)
        {
            if (id != tBorrow.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBorrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBorrowExists(tBorrow.BorrowId))
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
            return View(tBorrow);
        }

        // GET: TBorrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBorrows == null)
            {
                return NotFound();
            }

            var tBorrow = await _context.TBorrows
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (tBorrow == null)
            {
                return NotFound();
            }

            return View(tBorrow);
        }

        // POST: TBorrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBorrows == null)
            {
                return Problem("Entity set 'LibraryContext.TBorrows'  is null.");
            }
            var tBorrow = await _context.TBorrows.FindAsync(id);
            if (tBorrow != null)
            {
                _context.TBorrows.Remove(tBorrow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBorrowExists(int id)
        {
          return _context.TBorrows.Any(e => e.BorrowId == id);
        }
    }
}
