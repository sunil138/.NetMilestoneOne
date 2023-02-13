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
    public class TStudentsController : Controller
    {
        private readonly LibraryContext _context;

        public TStudentsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TStudents
        public async Task<IActionResult> Index()
        {
              return View(await _context.TStudents.ToListAsync());
        }

        // GET: TStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TStudents == null)
            {
                return NotFound();
            }

            var tStudent = await _context.TStudents
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tStudent == null)
            {
                return NotFound();
            }

            return View(tStudent);
        }

        // GET: TStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentAge,StudentGender,StudentAddress")] TStudent tStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tStudent);
        }

        // GET: TStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TStudents == null)
            {
                return NotFound();
            }

            var tStudent = await _context.TStudents.FindAsync(id);
            if (tStudent == null)
            {
                return NotFound();
            }
            return View(tStudent);
        }

        // POST: TStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentAge,StudentGender,StudentAddress")] TStudent tStudent)
        {
            if (id != tStudent.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TStudentExists(tStudent.StudentId))
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
            return View(tStudent);
        }

        // GET: TStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TStudents == null)
            {
                return NotFound();
            }

            var tStudent = await _context.TStudents
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tStudent == null)
            {
                return NotFound();
            }

            return View(tStudent);
        }

        // POST: TStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TStudents == null)
            {
                return Problem("Entity set 'LibraryContext.TStudents'  is null.");
            }
            var tStudent = await _context.TStudents.FindAsync(id);
            if (tStudent != null)
            {
                _context.TStudents.Remove(tStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TStudentExists(int id)
        {
          return _context.TStudents.Any(e => e.StudentId == id);
        }
    }
}
