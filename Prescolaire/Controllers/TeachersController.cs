using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;

namespace Prescolaire.Controllers
{
    public class TeachersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public TeachersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Teachers.Include(t => t.CreatedByNavigation).Include(t => t.Subject).Include(t => t.UpdatedByNavigation);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.CreatedByNavigation)
                .Include(t => t.Subject)
                .Include(t => t.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
                teacher.CreatedOn = DateTime.Now;
                teacher.UpdateOn = DateTime.Now;
                _context.Add(teacher);
                
                ApplicationUser user = new ApplicationUser();

                user.UserName = teacher.Email;
                user.Email = teacher.Email;
                user.EmailConfirmed = true;
                user.FirstName = teacher.FirstName;
                user.LastName = teacher.LastName;
                user.RoleId = "6020dbd3-a3f0-4094-9a61-d614cbc7d114";
                user.ModifiedBy = userEmail;
                user.ModifiedOn = DateTime.Now;


                var result = await _userManager.CreateAsync(user, teacher.Password);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Teacher");
                    if (roleResult.Succeeded)
                    {
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }

                }
            }
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", teacher.CreatedBy);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", teacher.SubjectId);
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", teacher.UpdatedBy);
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", teacher.CreatedBy);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", teacher.SubjectId);
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", teacher.UpdatedBy);
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.TeacherId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", teacher.CreatedBy);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", teacher.SubjectId);
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", teacher.UpdatedBy);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.CreatedByNavigation)
                .Include(t => t.Subject)
                .Include(t => t.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }
    }
}
