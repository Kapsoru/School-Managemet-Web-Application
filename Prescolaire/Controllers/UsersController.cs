using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;
using Prescolaire.ViewModel;
using System.Security.Claims;

namespace Prescolaire.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _context.Users.Include(x=>x.Role).ToListAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel userViewModel)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = new ApplicationUser();
            user.UserName = userViewModel.Email;
            user.Email = userViewModel.Email;
            user.EmailConfirmed = true;
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.RoleId = userViewModel.RoleId;
            user.ModifiedBy = userEmail;
            user.ModifiedOn = DateTime.Now;


            var result = await _userManager.CreateAsync(user,userViewModel.Password);

            if (result.Succeeded)
            {
                var roleName = _context.Roles.Find(userViewModel.RoleId).Name;
                var roleResult = await _userManager.AddToRoleAsync(user, roleName);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
             return View(userViewModel);
            
           
        }
    }
}
