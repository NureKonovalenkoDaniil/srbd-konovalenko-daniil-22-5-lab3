using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class Position
{
    public int PositionId { get; set; }

    public string Position1 { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
