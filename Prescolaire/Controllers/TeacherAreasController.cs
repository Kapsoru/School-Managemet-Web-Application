using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;
using Prescolaire.ViewModel;
using System.Linq;
using System.Security.Claims;

namespace Prescolaire.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherAreasController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public TeacherAreasController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Unauthorized();
            }
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherId = teacher.TeacherId;
            var myClasses = await _context.TeacherClasses
                                       .Where(tc => tc.TeacherId == teacherId)
                                       .Select(tc => tc.ClassId)
                                       .ToListAsync();

            var classesCount = myClasses.Count;

            var studentCount = await _context.StudentClasses
                                         .Where(sc => myClasses.Contains(sc.ClassId))
                                         .Select(sc => sc.StudentId)
                                         .Distinct()
                                         .CountAsync();

            var teacherAreaViewModel = new TeacherAreaViewModel
            {
                MyClassesCount = classesCount,
                MyStudentCount = studentCount
            };

            return View(teacherAreaViewModel);
        }

        public async Task<IActionResult> MyClasses()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (teacher == null)
            {
                return NotFound();
            }

            var myClasses = await _context.TeacherClasses
                                          .Where(tc => tc.TeacherId == teacher.TeacherId)
                                          .Include(tc => tc.Class)
                                          .ToListAsync();

            return View(myClasses);
        }
        public async Task<IActionResult> MyStudents()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (teacher == null)
            {
                return NotFound();
            }

            var myClasses = await _context.TeacherClasses
                                          .Where(tc => tc.TeacherId == teacher.TeacherId)
                                          .Select(tc => tc.ClassId)
                                          .ToListAsync();

            var students = await _context.StudentClasses
                                         .Where(sc => myClasses.Contains(sc.ClassId))
                                         .Include(sc => sc.Student)
                                         .ToListAsync();

            return View(students);
        }

        public async Task<IActionResult> Absense()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (teacher == null)
            {
                return NotFound();
            }

            var myClasses = await _context.TeacherClasses
                                          .Where(tc => tc.TeacherId == teacher.TeacherId)
                                          .Select(tc => tc.ClassId)
                                          .ToListAsync();

            var absences = await _context.Absences
                                          .Where(a => a.Student.StudentClasses.Any(sc => myClasses.Contains(sc.ClassId)))
                                          .Include(a => a.Student)
                                          .Include(a => a.SchoolYear)
                                          .ToListAsync();
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View(absences);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAbsense(Absence absence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Absense));
            }

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (teacher == null)
            {
                return NotFound();
            }

            var myClasses = await _context.TeacherClasses
                                          .Where(tc => tc.TeacherId == teacher.TeacherId)
                                          .Select(tc => tc.ClassId)
                                          .ToListAsync();

            ViewData["StudentId"] = new SelectList(
                await _context.Students
                              .Where(s => s.StudentClasses.Any(sc => myClasses.Contains(sc.ClassId)))
                              .ToListAsync(),
                "StudentId", "FirstName");

            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year");
            return View(absence);
        }

        public async Task<IActionResult> Marks()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Email == userEmail);
            if (teacher == null)
            {
                return NotFound();
            }

            var myClasses = await _context.TeacherClasses
                                          .Where(tc => tc.TeacherId == teacher.TeacherId)
                                          .Select(tc => tc.ClassId)
                                          .ToListAsync();

            var marks = await _context.Marks
                                      .Where(m => m.Student.StudentClasses.Any(sc => myClasses.Contains(sc.ClassId)) && m.SubjectId == teacher.SubjectId)
                                      .Include(m => m.Student)
                                      .Include(m => m.SchoolYear)
                                      .ToListAsync();

            return View(marks);
        }
        public async Task<IActionResult> EditMark(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                                     .Include(m => m.Student)
                                     .Include(m => m.SchoolYear)
                                     .Include(m => m.Subject) // Include the Subject to display it in the view
                                     .FirstOrDefaultAsync(m => m.MarkId == id);
            if (mark == null)
            {
                return NotFound();
            }

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", mark.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", mark.SubjectId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", mark.SchoolYearId);

            return View(mark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMark(int id, Mark mark)
        {
            if (id != mark.MarkId)
            {
                return NotFound();
            }

            ModelState.Remove("Student.Gender");
            ModelState.Remove("Student.DateOfBirth");

            if (ModelState.IsValid)
            {
                try
                {
                    var existingMark = await _context.Marks.FindAsync(id);
                    if (existingMark == null)
                    {
                        return NotFound();
                    }

                    // Update only relevant properties
                    existingMark.StudentId = mark.StudentId;
                    existingMark.SubjectId = mark.SubjectId;
                    existingMark.SchoolYearId = mark.SchoolYearId;
                    existingMark.Mark1 = mark.Mark1;
                    existingMark.Mark2 = mark.Mark2;

                    _context.Update(existingMark);
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
                return RedirectToAction(nameof(Marks));
            }

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", mark.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", mark.SubjectId);
            ViewData["SchoolYearId"] = new SelectList(_context.SchoolYear, "SchoolYearId", "Year", mark.SchoolYearId);

            return View(mark);
        }
        public async Task<IActionResult> TeacherProfile()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var teacher = await _context.Teachers
                                        .Include(t => t.Subject)
                                        .FirstOrDefaultAsync(t => t.Email == userEmail);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        private bool MarkExists(int id)
        {
            return _context.Marks.Any(e => e.MarkId == id);
        }



    }

}
