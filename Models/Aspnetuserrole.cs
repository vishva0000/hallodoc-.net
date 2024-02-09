using System;
using System.Collections.Generic;

namespace hallodoc.Models;

public partial class Aspnetuserrole
{
    public string Userid { get; set; } = null!;

    public string Roleid { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
