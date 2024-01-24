using System;
using System.Collections.Generic;

namespace firstapi.Models;

public partial class VsFlight
{
    public int FlightId { get; set; }

    public string? FlightName { get; set; }

    public string? Src { get; set; }

    public string? Dest { get; set; }

    public int? Rate { get; set; }

    public virtual ICollection<VsBookingDetail> VsBookingDetails { get; set; } = new List<VsBookingDetail>();
}
