using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("Marks")]
public partial class Mark
{
    [Key]
    [Column("markId")]
    public int MarkId { get; set; }

    [Column("studentId")]
    public int? StudentId { get; set; }

    [Column("subjectId")]
    public int? SubjectId { get; set; }

    [Column("mark1")]
    public double? Mark1 { get; set; }

    [Column("mark2")]
    public double? Mark2 { get; set; }

    [Column("schoolYearId")]
    public int SchoolYearId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Marks")]
    public virtual Student? Student { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Marks")]
    public virtual Subject? Subject { get; set; }

    [ForeignKey("SchoolYearId")]
    [InverseProperty("Marks")]
    public virtual SchoolYear? SchoolYear { get; set; }
}
