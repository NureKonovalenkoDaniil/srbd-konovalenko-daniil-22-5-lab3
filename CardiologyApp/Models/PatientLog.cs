using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class PatientLog
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTime ModifyDate { get; set; }
}
