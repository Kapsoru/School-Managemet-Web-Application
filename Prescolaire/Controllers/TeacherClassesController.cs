using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;

namespace Prescolaire.Controllers
{
    public class TeacherClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherClasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherClasses.Include(t => t.Class).Include(t => t.SchoolYear).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherClass = await _context.TeacherClasses
                .Include(t => t.Class)
                .Include(t => t.SchoolYear)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherClass1 == id);
            if (teacherClass == null)
            {
                return NotFound();
            }

            return View(teacherClass);
        }

        // GET: TeacherClasses/Create
        public IActionResult Create()
        {

            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableClasses(int teacherId, int schoolYearId)
        {
            // Get the subject of the selected class

            var selectedTeacher = await _context.Teachers.FirstOrDefaultAsync(c => c.TeacherId == teacherId);

            if (selectedTeacher == null)
            {
                return NotFound();
            }

            var subjectId = selectedTeacher.SubjectId;
            if (subjectId == 0)
            {
                return NotFound();
            }

            var availableClasses = await _context.Classes
         .Where(c => !c.TeacherClasses.Any(tc => tc.Teacher.SubjectId == subjectId && tc.SchoolYearId == schoolYearId))
         .ToListAsync();
            return Json(availableClasses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TeacherClass teacherClass)
        {
            
            if (ModelState.IsValid)
            {
                teacherClass.Teacher.Subject = await _context.Subjects.FindAsync(teacherClass.TeacherId);
                var existingTeacherClass = await _context.TeacherClasses
                    .AnyAsync(tc => tc.ClassId == teacherClass.ClassId
                                    && tc.Teacher.SubjectId == teacherClass.Teacher.SubjectId
                                    && tc.SchoolYearId == teacherClass.SchoolYearId);

                if (existingTeacherClass)
                {
                    ModelState.AddModelError("", "This class already has a teacher for the specified subject.");
                }
                else
                {
                    _context.Add(teacherClass);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", teacherClass.ClassId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", teacherClass.SchoolYearId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherClass.TeacherId);
            return View(teacherClass);
        }

        // GET: TeacherClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherClass = await _context.TeacherClasses.FindAsync(id);
            if (teacherClass == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", teacherClass.ClassId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", teacherClass.SchoolYearId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherClass.TeacherId);
            return View(teacherClass);
        }

        // POST: TeacherClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeacherClass teacherClass)
        {
            if (id != teacherClass.TeacherClass1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherClassExists(teacherClass.TeacherClass1))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", teacherClass.ClassId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", teacherClass.SchoolYearId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherClass.TeacherId);
            return View(teacherClass);
        }

        // GET: TeacherClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherClass = await _context.TeacherClasses
                .Include(t => t.Class)
                .Include(t => t.SchoolYear)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherClass1 == id);
            if (teacherClass == null)
            {
                return NotFound();
            }

            return View(teacherClass);
        }

        // POST: TeacherClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherClass = await _context.TeacherClasses.FindAsync(id);
            if (teacherClass != null)
            {
                _context.TeacherClasses.Remove(teacherClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherClassExists(int id)
        {
            return _context.TeacherClasses.Any(e => e.TeacherClass1 == id);
        }
    }
}
