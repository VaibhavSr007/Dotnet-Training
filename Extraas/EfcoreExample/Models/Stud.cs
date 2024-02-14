using System;
using System.Collections.Generic;

namespace EfcoreEx.Models;

public partial class Stud
{
    public int Sid { get; set; }

    public string? Sname { get; set; }

    public double? Marks { get; set; }

    public DateOnly? Dob { get; set; }
}
