using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightProject.Models;

public partial class VsSearch
{
    public int SearchId { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Desination")]
    public string? SearchDest { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Source")]
    public string? SearchSrc { get; set; }
}
