using System.ComponentModel.DataAnnotations;

namespace GacusanIII_UserManagement.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
