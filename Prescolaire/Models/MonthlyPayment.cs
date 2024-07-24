using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("MonthlyPayment")]
public partial class MonthlyPayment
{
    [Key]
    public int PaymentId { get; set; }

    [Column("studentId")]
    public int? StudentId { get; set; }

    [Column("paymentDate")]
    public DateOnly PaymentDate { get; set; }

    [Column("paymentMonth")]
    [StringLength(100)]
    public string PaymentMonth { get; set; } = null!;

    [Column("schoolYearId")]
    public int SchoolYearId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("MonthlyPayments")]
    public virtual Student? Student { get; set; }

    [ForeignKey("SchoolYearId")]
    [InverseProperty("MonthlyPayments")]
    public virtual SchoolYear SchoolYear { get; set; }
}
