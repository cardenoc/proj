using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GacusanIII_UserManagement.Models;

public partial class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }

    public ICollection<Person> Person { get; set; } = new List<Person>();
}
