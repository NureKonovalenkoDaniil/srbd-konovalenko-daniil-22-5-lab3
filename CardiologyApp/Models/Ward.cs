using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class Ward
{
    public int WardId { get; set; }

    public string Number { get; set; } = null!;

    public int NumBeds { get; set; }

    public string WardType { get; set; } = null!;

    public string Price { get; set; } = null!;

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<WardMedEquipment> WardMedEquipments { get; set; } = new List<WardMedEquipment>();
}
