using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("StudentClass")]
public partial class StudentClass
{
    [Key]
    [Column("studentClass")]
    public int StudentClass1 { get; set; }

    [Column("studentId")]
    [Required]
    public int? StudentId { get; set; }

    [Column("classId")]
    [Required]
    public int? ClassId { get; set; }

    [Column("schoolYearId")]
    [Required]
    public int SchoolYearId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("StudentClasses")]
    public virtual Class? Class { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentClasses")]
    public virtual Student? Student { get; set; }

    [ForeignKey("SchoolYearId")]
    [InverseProperty("StudentClasses")]
    public virtual SchoolYear? SchoolYear { get; set; }
}
