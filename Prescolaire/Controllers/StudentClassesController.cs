using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;

namespace Prescolaire.Controllers
{
    public class StudentClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentClasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentClasses.Include(s => s.Class).Include(s => s.SchoolYear).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                .Include(s => s.SchoolYear)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentClass1 == id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return View(studentClass);
        }

        // GET: StudentClasses/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentClass studentClass)
        {
            //studentClass.SchoolYear = _context.SchoolYear.Find(studentClass.SchoolYearId);

            var existingAssociation = await _context.StudentClasses
                    .AnyAsync(sc => sc.StudentId == studentClass.StudentId && sc.SchoolYearId == studentClass.SchoolYearId);
            if (ModelState.IsValid)
            {

                if (existingAssociation)
                {
                    ModelState.AddModelError("", "The student is already attached to another class for the selected school year.");

                    ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", studentClass.ClassId);
                    ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", studentClass.SchoolYearId);
                    ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentClass.StudentId);
                    return View(studentClass);
                }
                else
                {
                    // Ensure the class capacity is not exceeded
                    var classEntity = await _context.Classes
                        .Include(c => c.StudentClasses)
                        .FirstOrDefaultAsync(c => c.ClassId == studentClass.ClassId);

                    if (classEntity != null && classEntity.StudentClasses.Count >= classEntity.Capacity)
                    {
                        ModelState.AddModelError("", "The class has reached its capacity.");
                    }
                    else
                    {
                        _context.Add(studentClass);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            var errors = ModelState.SelectMany(x => x.Value.Errors)
                          .Select(x => x.ErrorMessage)
                          .ToList();

            // You can add a breakpoint here to inspect the errors or log them
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error); // or use any logging mechanism
            }


            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", studentClass.ClassId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", studentClass.SchoolYearId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentClass.StudentId);
            return View(studentClass);
        }

        // GET: StudentClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses.FindAsync(id);
            if (studentClass == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", studentClass.ClassId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", studentClass.SchoolYearId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentClass.StudentId);
            return View(studentClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentClass studentClass)
        {
            if (id != studentClass.StudentClass1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                
                try
                {
                    _context.Update(studentClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentClassExists(studentClass.StudentClass1))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", studentClass.ClassId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", studentClass.SchoolYearId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentClass.StudentId);
            return View(studentClass);
        }

        // GET: StudentClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                .Include(s => s.SchoolYear)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentClass1 == id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return View(studentClass);
        }

        // POST: StudentClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentClass = await _context.StudentClasses.FindAsync(id);
            if (studentClass != null)
            {
                _context.StudentClasses.Remove(studentClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentClassExists(int id)
        {
            return _context.StudentClasses.Any(e => e.StudentClass1 == id);
        }
    }
}
