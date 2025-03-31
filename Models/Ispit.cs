using System;
using System.Collections.Generic;

namespace StudentskaWebAPI.Models;

public partial class Ispit
{
    public int IdIspita { get; set; }

    public int IdRoka { get; set; }

    public int IdPredmeta { get; set; }

    public DateTime Datum { get; set; }

    public virtual Predmet IdPredmetaNavigation { get; set; } = null!;

    public virtual IspitniRok IdRokaNavigation { get; set; } = null!;

    public virtual ICollection<Zapisnik> Zapisniks { get; set; } = new List<Zapisnik>();
}
