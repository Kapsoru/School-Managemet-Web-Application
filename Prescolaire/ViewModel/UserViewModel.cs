using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Prescolaire.ViewModel
{
    public class UserViewModel
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public DateTime? LoginDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? PasswordChangeOn { get; set; }
        public string? RoleId { get; set; }
    }
}
