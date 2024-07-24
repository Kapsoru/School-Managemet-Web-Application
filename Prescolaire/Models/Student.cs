using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Validators;

namespace Prescolaire.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("studentId")]
    public int StudentId { get; set; }

    [Column("firstName")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("lastName")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    [Column("dateOfBirth")]
    [AgeRange(4, 12, ErrorMessage = "Age must be between 4 and 12 years.")]
    public DateOnly DateOfBirth { get; set; }

    [Column("street")]
    [StringLength(100)]
    public string? Street { get; set; }

    [Column("city")]
    [StringLength(100)]
    public string? City { get; set; }

    [Column("region")]
    [StringLength(50)]
    public string? Region { get; set; }

    [Column("country")]
    [StringLength(100)]
    public string? Country { get; set; }

    [Column("postalCode")]
    [StringLength(100)]
    public string? PostalCode { get; set; }

    [Column("parentName")]
    [StringLength(100)]
    public string? ParentName { get; set; }

    [Column("phoneNumber")]
    [StringLength(100)]
    public string? PhoneNumber { get; set; }

    [Column("email")]
    [StringLength(200)]
    [EmailAddress]
    public string? Email { get; set; }

    [Column("password")]
    [StringLength(200)]
    public string? Password { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column("createdBy")]
    public int? CreatedBy { get; set; }

    [Column("updatedBy")]
    public int? UpdatedBy { get; set; }

    [Column("createdOn", TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    [Column("updateOn", TypeName = "datetime")]
    public DateTime UpdateOn { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("StudentCreatedByNavigations")]
    public virtual Manager? CreatedByNavigation { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    [InverseProperty("Student")]
    public virtual ICollection<MonthlyPayment> MonthlyPayments { get; set; } = new List<MonthlyPayment>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("StudentUpdatedByNavigations")]
    public virtual Manager? UpdatedByNavigation { get; set; }
}
