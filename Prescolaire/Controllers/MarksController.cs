using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;
using Prescolaire.ViewModel;

namespace Prescolaire.Controllers
{
    [Authorize]
    public class MarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index(int? selectedClassId, int? selectedStudentId, int? selectedSchoolYearId)
        {
            var classes = await _context.Classes
                .Select(c => new SelectListItem
                {
                    Value = c.ClassId.ToString(),
                    Text = c.ClassName
                }).ToListAsync();

            var students = await _context.Students
                .Select(s => new SelectListItem
                {
                    Value = s.StudentId.ToString(),
                    Text = s.FirstName + " " + s.LastName
                }).ToListAsync();

            var schoolYears = await _context.SchoolYear
                .Select
                (sy => new SelectListItem
                {
                    Value = sy.SchoolYearId.ToString(),
                    Text = sy.Year
                }).ToListAsync();

            var marksQuery = _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.SchoolYear)
                .AsQueryable();

            if (selectedClassId.HasValue)
            {
                var studentIdsInClass = await _context.StudentClasses
                    .Where(sc => sc.ClassId == selectedClassId.Value)
                    .Select(sc => sc.StudentId)
                    .ToListAsync();

                marksQuery = marksQuery.Where(m => studentIdsInClass.Contains(m.StudentId.Value));
            }

            if (selectedStudentId.HasValue)
            {
                marksQuery = marksQuery.Where(m => m.StudentId == selectedStudentId.Value);
            }

            if (selectedSchoolYearId.HasValue)
            {
                marksQuery = marksQuery.Where(m => m.SchoolYearId == selectedSchoolYearId.Value);
            }

            var marks = await marksQuery.ToListAsync();

            var viewModel = new MarkFilterViewModel
            {
                SelectedClassId = selectedClassId,
                SelectedStudentId = selectedStudentId,
                SelectedSchoolYearId = selectedSchoolYearId,
                Classes = classes,
                Students = students,
                SchoolYears = schoolYears,
                Marks = marks
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Filter(int? selectedClassId, int? selectedStudentId, int? selectedSchoolYearId)
        {
            var marksQuery = _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.SchoolYear)
                .AsQueryable();

            if (selectedClassId.HasValue)
            {
                var studentIdsInClass = await _context.StudentClasses
                    .Where(sc => sc.ClassId == selectedClassId.Value)
                    .Select(sc => sc.StudentId)
                    .ToListAsync();

                marksQuery = marksQuery.Where(m => studentIdsInClass.Contains(m.StudentId.Value));
            }

            if (selectedStudentId.HasValue)
            {
                marksQuery = marksQuery.Where(m => m.StudentId == selectedStudentId.Value);
            }

            if (selectedSchoolYearId.HasValue)
            {
                marksQuery = marksQuery.Where(m => m.SchoolYearId == selectedSchoolYearId.Value);
            }

            var marks = await marksQuery.ToListAsync();

            var viewModel = new MarkFilterViewModel
            {
                SelectedClassId = selectedClassId,
                SelectedStudentId = selectedStudentId,
                SelectedSchoolYearId = selectedSchoolYearId,
                Marks = marks
            };

            return PartialView("_MarksTable", viewModel);
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.MarkId == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateMarks(int schoolYearId)
        {
            var selectedSchoolYear = await _context.SchoolYear.FindAsync(schoolYearId);
            if (selectedSchoolYear == null)
            {
                return NotFound("Selected school year not found.");
            }

            var students = await _context.Students.Include(s => s.StudentClasses).ToListAsync();
            var subjects = await _context.Subjects.ToListAsync();

            foreach (var student in students)
            {
                foreach (var studentClass in student.StudentClasses.Where(sc => sc.SchoolYearId == selectedSchoolYear.SchoolYearId))
                {
                    foreach (var subject in subjects)
                    {
                        var existingMark = await _context.Marks
                            .FirstOrDefaultAsync(m => m.StudentId == student.StudentId
                                                       && m.SubjectId == subject.SubjectId
                                                       && m.SchoolYearId == selectedSchoolYear.SchoolYearId);
                        if (existingMark == null)
                        {
                            var mark = new Mark
                            {
                                StudentId = student.StudentId,
                                SubjectId = subject.SubjectId,
                                SchoolYearId = selectedSchoolYear.SchoolYearId,
                                Mark1 = null,
                                Mark2 = null
                            };
                            _context.Marks.Add(mark);
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", mark.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", mark.SubjectId);
            return View(mark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", mark.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", mark.SubjectId);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Mark mark)
        {
            if (id != mark.MarkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.MarkId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", mark.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", mark.SubjectId);
            return View(mark);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.MarkId == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Marks.FindAsync(id);
            if (mark != null)
            {
                _context.Marks.Remove(mark);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Marks.Any(e => e.MarkId == id);
        }
    }
}
