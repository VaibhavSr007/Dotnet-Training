using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flightProject.Models;

public partial class Customers
{   
    
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Enter a Valid Email Address")]
    public string? CustomerEmail { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Name")]
    public string? CustomerName { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Password")]
    public string? CustomerPass { get; set; }

    [NotMapped]
    [Compare("CustomerPass", ErrorMessage = "Passwords do not match")]
    [Display(Name = "Confirm Password")]
    public string? ConfirmPass { get; set; }

}
