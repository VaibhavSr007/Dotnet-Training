﻿using System;
using System.Collections.Generic;

namespace bank.Models;

public partial class SbaccountJay
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<SbtransactionJay> SbtransactionJays { get; set; } = new List<SbtransactionJay>();
}
