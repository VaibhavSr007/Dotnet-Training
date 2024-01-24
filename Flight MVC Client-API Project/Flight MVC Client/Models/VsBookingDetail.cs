using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightProject.Models;

public partial class VsBookingDetail
{
    
    public int BookingId { get; set; }

    [Display(Name = "Flight Id")]
    public int? FlightId { get; set; }

     [Display(Name = "Customer Id")]
    public int? CustomerId { get; set; }

     [Display(Name = "Travel Date")]
    [Required(ErrorMessage = "*")]
    [DataType(DataType.DateTime, ErrorMessage = "Please Enter a Valid Email")]
    public DateTime? TravelDate { get; set; }

     [Display(Name = "Number of Passengers")]
    [Required(ErrorMessage = "*")]
    public int? NoOfPassengers { get; set; }

    [Display(Name = "Total Fare")]
    public int? TotalPrice { get; set; }

    public virtual VsCustomer? Customer { get; set; }

    public virtual VsFlight? Flight { get; set; }
}
