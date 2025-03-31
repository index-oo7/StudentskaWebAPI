using System;
using System.Collections.Generic;

namespace StudentskaWebAPI.Models;

public partial class Predmet
{
    public int IdPredmeta { get; set; }

    public int IdProfesora { get; set; }

    public string Naziv { get; set; } = null!;

    public int Espb { get; set; }

    public string? Status { get; set; }

    public virtual Profesor IdProfesoraNavigation { get; set; } = null!;

    public virtual ICollection<Ispit> Ispits { get; set; } = new List<Ispit>();

    public virtual ICollection<StudentPredmet> StudentPredmets { get; set; } = new List<StudentPredmet>();
}
