using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("Class")]
public partial class Class
{
    [Key]
    [Column("classId")]
    public int ClassId { get; set; }

    [Column("className")]
    [StringLength(200)]
    public string ClassName { get; set; } = null!;

    [Column("capacity")]
    public int Capacity { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    [InverseProperty("Class")]
    public virtual ICollection<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();
}
