using System;
using System.Collections.Generic;

namespace StudentskaWebAPI.Models;

public partial class StudentPredmet
{
    public int IdStudenta { get; set; }

    public int IdPredmeta { get; set; }

    public string? SkolskaGodina { get; set; }

    public virtual Predmet IdPredmetaNavigation { get; set; } = null!;

    public virtual Student IdStudentaNavigation { get; set; } = null!;
}
