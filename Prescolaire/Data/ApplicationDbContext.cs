using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Models;

namespace Prescolaire.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<MonthlyPayment> MonthlyPayments { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentClass> StudentClasses { get; set; }

        public virtual DbSet<StudentGrade> StudentGrades { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<TeacherClass> TeacherClasses { get; set; }
        public virtual DbSet<SystemProfile> SystemProfiles { get; set; }
        public virtual DbSet<SchoolYear> SchoolYear { get; set; }
    }
}
