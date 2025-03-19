using System;
using System.Collections.Generic;

namespace PR17;

public partial class Student
{
    public int Id { get; set; }

    public string Familia { get; set; } = null!;

    public string Ima { get; set; } = null!;

    public string Otchestvo { get; set; } = null!;

    public int IdZachetnoKinigi { get; set; }

    public bool? ChivetVobchaga { get; set; }

    public int IdGruppa { get; set; }

    public bool? Math { get; set; }

    public bool? History { get; set; }

    public bool? Informatic { get; set; }

    public bool? PhysicalEdication { get; set; }

    public bool? English { get; set; }
}
