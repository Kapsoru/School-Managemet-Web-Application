using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prescolaire.Models;

[Table("Manager")]
public partial class Manager
{
    [Key]
    [Column("managerid")]
    public int Managerid { get; set; }

    [Column("firstName")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("lastName")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [Column("username")]
    [StringLength(100)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(200)]
    public string Password { get; set; } = null!;

    [Column("email")]
    [StringLength(200)]
    public string Email { get; set; } = null!;

    [Column("isActive")]
    public bool IsActive { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Student> StudentCreatedByNavigations { get; set; } = new List<Student>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Student> StudentUpdatedByNavigations { get; set; } = new List<Student>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Teacher> TeacherCreatedByNavigations { get; set; } = new List<Teacher>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Teacher> TeacherUpdatedByNavigations { get; set; } = new List<Teacher>();
}
