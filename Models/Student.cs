using System;
using System.Collections.Generic;

namespace StudentskaWebAPI.Models;

public partial class Student
{
    public int IdStudenta { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string? Smer { get; set; }

    public int Broj { get; set; }

    public string? GodinaUpisa { get; set; }

    public virtual ICollection<StudentPredmet> StudentPredmets { get; set; } = new List<StudentPredmet>();

    public virtual ICollection<Zapisnik> Zapisniks { get; set; } = new List<Zapisnik>();
}
