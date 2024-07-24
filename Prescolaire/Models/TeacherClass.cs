using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("TeacherClass")]
public partial class TeacherClass
{
    [Key]
    [Column("teacherClass")]
    public int TeacherClass1 { get; set; }

    [Column("classId")]
    public int? ClassId { get; set; }

    [Column("teacherId")]
    public int? TeacherId { get; set; }

    [Column("schoolYearId")]
    public int SchoolYearId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("TeacherClasses")]
    public virtual Class? Class { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("TeacherClasses")]
    public virtual Teacher? Teacher { get; set; }

    [ForeignKey("SchoolYearId")]
    [InverseProperty("TeacherClasses")]
    public virtual SchoolYear? SchoolYear { get; set; }
}