using System;
using System.Collections.Generic;

namespace StudentskaWebAPI.Models;

public partial class Profesor
{
    public int IdProfesora { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string? Zvanje { get; set; }

    public DateTime? DatumZap { get; set; }

    public virtual ICollection<Predmet> Predmets { get; set; } = new List<Predmet>();
}
