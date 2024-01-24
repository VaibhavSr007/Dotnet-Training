using System;
using System.Collections.Generic;

namespace firstapi.Models;

public partial class VsSearch
{
    public int SearchId { get; set; }

    public string? SearchDest { get; set; }

    public string? SearchSrc { get; set; }
}
