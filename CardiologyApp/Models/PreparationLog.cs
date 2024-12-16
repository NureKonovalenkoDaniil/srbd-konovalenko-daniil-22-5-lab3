using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class PreparationLog
{
    public int Id { get; set; }

    public DateTime AttemptDate { get; set; }

    public string AttemptType { get; set; } = null!;

    public string Message { get; set; } = null!;
}
