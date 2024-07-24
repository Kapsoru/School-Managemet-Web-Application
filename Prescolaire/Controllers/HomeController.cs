using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;
using Prescolaire.ViewModel;
using System.Diagnostics;
using System.Security.Claims;

namespace Prescolaire.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel
            {
                StudentCount = _context.Students.Count(),
                TeachersCount = _context.Teachers.Count(),
                ClassesCount = _context.Classes.Count()
            };
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("~/identity/account/login");
            }
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Unauthorized();
            }
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Manager"))
            {
                // Redirect to manager dashboard
                return View(viewModel);
            }
            else if (roles.Contains("Teacher"))
            {
                // Redirect to teacher dashboard
                return RedirectToAction("Index", "TeacherAreas");
            }
            else if (roles.Contains("Student"))
            {
                // Redirect to student dashboard
                return RedirectToAction("Index","Parent");
            }

            // If no roles match, return default view
            return Unauthorized();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
