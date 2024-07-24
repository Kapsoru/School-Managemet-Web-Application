using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("Absence")]
public partial class Absence
{
    [Key]
    [Column("absenceId")]
    public int AbsenceId { get; set; }

    [Column("studentId")]
    public int? StudentId { get; set; }

    [Column("absenceDate", TypeName = "datetime")]
    public DateTime AbsenceDate { get; set; }

    [Column("schoolYearId")]
    public int SchoolYearId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Absences")]
    public virtual Student? Student { get; set; }

    [ForeignKey("SchoolYearId")]
    [InverseProperty("Absences")]
    public virtual SchoolYear? SchoolYear { get; set; }
}
