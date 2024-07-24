using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Data;
using Prescolaire.Models;
using Prescolaire.ViewModel;

namespace Prescolaire.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public StudentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Students.Include(s => s.CreatedByNavigation).Include(s => s.UpdatedByNavigation);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CreatedByNavigation)
                .Include(s => s.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid");
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Student student)
        {
            if (ModelState.IsValid)
            {
               // student.CreatedBy = "Admin";
                student.CreatedOn = DateTime.Now;
                student.UpdateOn = DateTime.Now;
                _context.Add(student);


                ApplicationUser user = new ApplicationUser();

                user.UserName = student.Email;
                user.Email = student.Email;
                user.EmailConfirmed = true;
                user.FirstName = student.FirstName;
                user.LastName = student.LastName;
                user.RoleId = "7a90e92a-b566-4a07-a9c1-bf1d8b6b565b";
                user.ModifiedBy = "Admin";
                user.ModifiedOn = DateTime.Now;


                var result = await _userManager.CreateAsync(user, student.Password);
                if (result.Succeeded)
                {
                   var roleResult = await _userManager.AddToRoleAsync(user, "Student");
                    if (roleResult.Succeeded)
                    {
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    
                }               
            }
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", student.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", student.UpdatedBy);
            
           
            return View(student);
            
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", student.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", student.UpdatedBy);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", student.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Managers, "Managerid", "Managerid", student.UpdatedBy);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CreatedByNavigation)
                .Include(s => s.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
