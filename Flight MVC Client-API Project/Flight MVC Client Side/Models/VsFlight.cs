using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightProject.Models;

public partial class VsFlight
{

    public int FlightId { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Flight Name")]
    public string? FlightName { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Source")]
    public string? Src { get; set; }

    [Display(Name = "Destination")]
    [Required(ErrorMessage = "*")]
    public string? Dest { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Price per Ticket")]
    public int? Rate { get; set; }

    public virtual ICollection<VsBookingDetail> VsBookingDetails { get; set; } = new List<VsBookingDetail>();
}
