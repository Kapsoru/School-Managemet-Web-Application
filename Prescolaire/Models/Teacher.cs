using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Prescolaire.Validators;

namespace Prescolaire.Models;

[Table("Teacher")]
public partial class Teacher
{
    [Key]
    [Column("teacherId")]
    public int TeacherId { get; set; }

    [Column("subjectId")]
    public int? SubjectId { get; set; }

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
    [AgeRange(21, 40, ErrorMessage = "Age must be between 21 and 40 years.")]
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

    [ForeignKey("CreatedBy")]
    [InverseProperty("TeacherCreatedByNavigations")]
    public virtual Manager? CreatedByNavigation { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Teachers")]
    public virtual Subject? Subject { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("TeacherUpdatedByNavigations")]
    public virtual Manager? UpdatedByNavigation { get; set; }
}
