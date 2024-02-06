using System;
using System.Collections;
using System.Collections.Generic;

namespace hallodoc.Models;

public partial class Admin
{
    public int Adminid { get; set; }

    public string? Aspnetuserid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string Email { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public int? Regionid { get; set; }

    public string? Zip { get; set; }

    public string? Altphone { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public string? Modifiedby { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Status { get; set; }

    public BitArray? Isdeleted { get; set; }

    public int? Roleid { get; set; }

    public virtual ICollection<Adminregion> Adminregions { get; set; } = new List<Adminregion>();

    public virtual Aspnetuser? Aspnetuser { get; set; }

    public virtual Aspnetuser? ModifiedbyNavigation { get; set; }
}
