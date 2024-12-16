using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class MedEquipment
{
    public int MedEquipmentId { get; set; }

    public string Title { get; set; } = null!;

    public int Amount { get; set; }

    public int WearLevel { get; set; }

    public virtual ICollection<WardMedEquipment> WardMedEquipments { get; set; } = new List<WardMedEquipment>();
}
