using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightProject.Models;

public partial class VsBookingDetail
{
    [Display(Name = "Booking ID")]
    public int BookingId { get; set; }

    [Display(Name = "Flight ID")]
    public int? FlightId { get; set; }

    [Display(Name = "Customer ID")]
    public int? CustomerId { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Must be in Date Time Format")]
    [Required(ErrorMessage = "*")]
    [Display(Name = "Date of Travel")]
    public DateTime? TravelDate { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Number of Passengers")]
    public int? NoOfPassengers { get; set; }

    [Display(Name = "Total Price")]
    public int? TotalPrice { get; set; }

    public virtual VsCustomer? Customer { get; set; }

    public virtual VsFlight? Flight { get; set; }
}
