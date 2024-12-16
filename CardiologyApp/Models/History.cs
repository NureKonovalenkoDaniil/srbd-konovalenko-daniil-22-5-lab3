using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class History
{
    public int HistoryId { get; set; }

    public string NumberHistory { get; set; } = null!;

    public DateOnly ReceiptDate { get; set; }

    public DateOnly? DischargeDate { get; set; }

    public string Diagnos { get; set; } = null!;

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? WardId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<HistoryPreparation> HistoryPreparations { get; set; } = new List<HistoryPreparation>();

    public virtual Patient? Patient { get; set; }

    public virtual Ward? Ward { get; set; }
}
