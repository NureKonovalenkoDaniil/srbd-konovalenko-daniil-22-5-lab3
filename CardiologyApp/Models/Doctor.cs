using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public int? PositionId { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Position? Position { get; set; }
}
