using System;
using System.Collections.Generic;

namespace loginmvcex.Models;

public partial class UserVai
{
    public string Email { get; set; } = null!;

    public string? Pass { get; set; }

    public string? Username { get; set; }
}
