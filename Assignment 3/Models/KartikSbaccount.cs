﻿using System;
using System.Collections.Generic;

namespace bank.Models;

public partial class KartikSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public double? CurrentBalance { get; set; }
}
