using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("StudentGrade")]
public partial class StudentGrade
{
    [Key]
    [Column("studentGradeId")]
    public int StudentGradeId { get; set; }

    [Column("studentId")]
    public int? StudentId { get; set; }

    [Column("gradeId")]
    public int? GradeId { get; set; }

    [ForeignKey("GradeId")]
    [InverseProperty("StudentGrades")]
    public virtual Grade? Grade { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentGrades")]
    public virtual Student? Student { get; set; }
}
