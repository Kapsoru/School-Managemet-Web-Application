using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("Grade")]
public partial class Grade
{
    [Key]
    [Column("gradeId")]
    public int GradeId { get; set; }

    [Column("gradeName")]
    [StringLength(100)]
    public string GradeName { get; set; } = null!;

    [InverseProperty("Grade")]
    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
}
