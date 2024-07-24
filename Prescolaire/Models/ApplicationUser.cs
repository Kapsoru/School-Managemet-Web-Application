using Microsoft.AspNetCore.Identity;

namespace Prescolaire.Models
{
    public class ApplicationUser : IdentityUser
    {
         public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public DateTime? LoginDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
       public DateTime? PasswordChangeOn { get; set; }
        public string? RoleId { get; set; }
        public IdentityRole? Role { get; set; }


    }
}
