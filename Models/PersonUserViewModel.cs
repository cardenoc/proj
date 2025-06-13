using System.ComponentModel.DataAnnotations;

namespace GacusanIII_UserManagement.Models
{
    public class PersonUserViewModel
    {
        // Person fields
        public int PersonId { get; set; }
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        // User fields
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }

}
