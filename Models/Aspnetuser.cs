using System;
using System.Collections;
using System.Collections.Generic;

namespace hallodoc.Models;

public partial class Aspnetuser
{
    public string Id { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Passwordhash { get; set; }

    public string? Securitystamp { get; set; }

    public string? Email { get; set; }

    public BitArray Emailconfirmed { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public BitArray Phonenumberconfirmed { get; set; } = null!;

    public BitArray Twofactorenabled { get; set; } = null!;

    public DateTime? Lockoutenddateutc { get; set; }

    public BitArray Lockoutenabled { get; set; } = null!;

    public int Accessfailedcount { get; set; }

    public string? Ip { get; set; }

    public string? Corepasswordhash { get; set; }

    public int? Hashversion { get; set; }

    public DateTime? Modifieddate { get; set; }

    public virtual ICollection<Admin> AdminAspnetusers { get; set; } = new List<Admin>();

    public virtual ICollection<Admin> AdminModifiedbyNavigations { get; set; } = new List<Admin>();

    public virtual ICollection<Aspnetuserrole> Aspnetuserroles { get; set; } = new List<Aspnetuserrole>();
}
