﻿using System;
using System.Collections.Generic;

namespace bank.Models;

public partial class SbaccountHetal
{
    public int AccountNo { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public double? CurrBalance { get; set; }
}
