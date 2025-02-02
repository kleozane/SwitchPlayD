using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SwitchPlayD.Identity
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string? UserType { get; set; }
        public string? Position { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? UserIdCard { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
