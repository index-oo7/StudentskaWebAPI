using System;
using System.Collections.Generic;

namespace StudentskaWebAPI.Models;

public partial class IspitniRok
{
    public int IdRoka { get; set; }

    public string Naziv { get; set; } = null!;

    public string? SkolskaGod { get; set; }

    public string? StatusRoka { get; set; }

    public virtual ICollection<Ispit> Ispits { get; set; } = new List<Ispit>();
}
