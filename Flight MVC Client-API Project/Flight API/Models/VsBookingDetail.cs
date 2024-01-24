using System;
using System.Collections.Generic;

namespace firstapi.Models;

public partial class VsBookingDetail
{
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? TravelDate { get; set; }

    public int? NoOfPassengers { get; set; }

    public int? TotalPrice { get; set; }

    public virtual VsCustomer? Customer { get; set; }

    public virtual VsFlight? Flight { get; set; }
}
