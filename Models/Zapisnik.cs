using System;
using System.Collections.Generic;

namespace StudentskaWebAPI.Models;

public partial class Zapisnik
{
    public int IdStudenta { get; set; }

    public int IdIspita { get; set; }

    public double Ocena { get; set; }

    public string? Bodovi { get; set; }

    public virtual Ispit IdIspitaNavigation { get; set; } = null!;

    public virtual Student IdStudentaNavigation { get; set; } = null!;
}
