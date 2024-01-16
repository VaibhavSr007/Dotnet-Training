using System;
using System.Collections.Generic;

namespace bank.Models;

public partial class AryanSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<AryanSbtransaction> AryanSbtransactions { get; set; } = new List<AryanSbtransaction>();
}
