using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("Subject")]
public partial class Subject
{
    [Key]
    [Column("subjectId")]
    public int SubjectId { get; set; }

    [Column("subjectName")]
    [StringLength(200)]
    public string SubjectName { get; set; } = null!;

    [InverseProperty("Subject")]
    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    [InverseProperty("Subject")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
