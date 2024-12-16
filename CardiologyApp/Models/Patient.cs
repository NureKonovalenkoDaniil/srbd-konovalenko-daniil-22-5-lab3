using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FullName { get; set; } = null!;

    public int Age { get; set; }

    public string Adress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
