using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class Preparation
{
    public int PreparationId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly ExpirationDate { get; set; }

    public DateOnly DateReceipt { get; set; }

    public string Price { get; set; } = null!;

    public int Amount { get; set; }

    public int? ManufacturerId { get; set; }

    public virtual ICollection<HistoryPreparation> HistoryPreparations { get; set; } = new List<HistoryPreparation>();

    public virtual Manufacturer? Manufacturer { get; set; }
}
