using System;
using System.Collections.Generic;

namespace firstapi.Models;

public partial class VsCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerPass { get; set; }

    public virtual ICollection<VsBookingDetail> VsBookingDetails { get; set; } = new List<VsBookingDetail>();
}
