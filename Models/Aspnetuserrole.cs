﻿using System;
using System.Collections.Generic;

namespace hallodoc.Models;

public partial class Aspnetuserrole
{
    public string Userid { get; set; } = null!;

    public string Roleid { get; set; } = null!;

    public virtual Aspnetuser User { get; set; } = null!;
}
