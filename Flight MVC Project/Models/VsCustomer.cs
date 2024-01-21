using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flightProject.Models;

public partial class VsCustomer
{
    
    [Display(Name = "Customer ID")]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string? CustomerEmail { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Name")]
    public string? CustomerName { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Password")]
    public string? CustomerPass { get; set; }

    // [Required(ErrorMessage ="*")]
    [NotMapped]
    [Compare("CustomerPass",ErrorMessage = "Password do not match")]
    public string? ConfirmPass { get; set; }
    public virtual ICollection<VsBookingDetail> VsBookingDetails { get; set; } = new List<VsBookingDetail>();
}
