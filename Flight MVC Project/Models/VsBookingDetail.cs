using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightProject.Models;

public partial class VsBookingDetail
{
    
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? CustomerId { get; set; }

    [Required(ErrorMessage = "*")]
    [DataType(DataType.DateTime, ErrorMessage = "Please Enter a Valid Email")]
    public DateTime? TravelDate { get; set; }

    [Required(ErrorMessage = "*")]
    public int? NoOfPassengers { get; set; }

    public int? TotalPrice { get; set; }

    public virtual VsCustomer? Customer { get; set; }

    public virtual VsFlight? Flight { get; set; }
}
