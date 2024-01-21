using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightProject.Models;

public partial class VsFlight
{
    [Display(Name = "Flight ID")]
    public int FlightId { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Flight Name")]
    public string? FlightName { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Source")]
    public string? Src { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Destination")]
    public string? Dest { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Price per ticket")]
    public int? Rate { get; set; }

    public virtual ICollection<VsBookingDetail> VsBookingDetails { get; set; } = new List<VsBookingDetail>();
}
