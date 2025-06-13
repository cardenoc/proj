using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GacusanIII_UserManagement.Models;

public partial class Person
{
    public int Id { get; set; }

    [Required]
    public string Firstname { get; set; }

    [Required]
    public string Lastname { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int UserId { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
