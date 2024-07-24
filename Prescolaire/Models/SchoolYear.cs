using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prescolaire.Models
{

    [Table("SchoolYear")]
    public class SchoolYear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolYearId { get; set; }

        [Required]
        [StringLength(100)]
        public string Year { get; set; }

        [InverseProperty("SchoolYear")]
        public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

        [InverseProperty("SchoolYear")]
        public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

        [InverseProperty("SchoolYear")]
        public virtual ICollection<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();

        [InverseProperty("SchoolYear")]
        public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

        [InverseProperty("SchoolYear")]
        public virtual ICollection<MonthlyPayment> MonthlyPayments { get; set; } = new List<MonthlyPayment>();
    }

}
