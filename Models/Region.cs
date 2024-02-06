using System;
using System.Collections.Generic;

namespace hallodoc.Models;

public partial class Region
{
    public int Regionid { get; set; }

    public string Name { get; set; } = null!;

    public string? Abbreviation { get; set; }

    public virtual ICollection<Adminregion> Adminregions { get; set; } = new List<Adminregion>();
}
