using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Prescolaire.Data;
using Prescolaire.Models;
using Prescolaire.ViewModel;
using System.Security.Claims;
using static Prescolaire.ViewModel.StudentMarksViewModel;

namespace Prescolaire.Controllers
{
    [Authorize(Roles = "Student")]
    public class ParentController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ParentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
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

            var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == userEmail);
            return View(student);

        }

        public async Task<IActionResult> StudentMarks()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var student = await _context.Students
                .Include(g => g.StudentGrades)
                .Include(s => s.Marks)
                .ThenInclude(m => m.Subject)
                .FirstOrDefaultAsync(s => s.Email == userEmail);

            if (student == null)
            {
                return NotFound();
            }

            var subjectMarks = student.Marks.Select(m => new StudentMarksViewModel.SubjectMark
            {
                SubjectName = m.Subject.SubjectName,
                Mark1 = m.Mark1,
                Mark2 = m.Mark2,
                AverageSubejectMark = (m.Mark1 + m.Mark2) / 2
            }).ToList();

            var allMarks = subjectMarks.Select(sm => sm.AverageSubejectMark).Where(mark => mark.HasValue).Select(mark => mark.Value).ToList();
            var averageMark = allMarks.Count > 0 ? allMarks.Average() : 0;
            var grade = student.StudentGrades.Where(sg => sg.StudentId == student.StudentId).LastOrDefault()?.Grade?.GradeName ?? "No grade available";

            var viewModel = new StudentMarksViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Grade = grade,
                SubjectMarks = subjectMarks,
                AverageMark = averageMark,
                IsPassed = allMarks.Count > 0 && averageMark >= 5
            };

            return View("StudentMarks", viewModel);
        }
        public async Task<IActionResult> StudentAbsenses()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var student = await _context.Students.Include(g => g.StudentGrades)
                                        .Include(s => s.Marks)
                                        .ThenInclude(m => m.Subject)
                                        .FirstOrDefaultAsync(s => s.Email == userEmail);

            if (student == null)
            {
                return NotFound();
            }
            return View("StudentAbsenses", _context.Absences.Where(a=>a.StudentId== student.StudentId));
        }
    }
}
