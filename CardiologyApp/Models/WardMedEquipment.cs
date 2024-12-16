using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class WardMedEquipment
{
    public int WardMedEquipmentId { get; set; }

    public int Condition { get; set; }

    public DateOnly ReviewDate { get; set; }

    public DateOnly EntryDate { get; set; }

    public int? WardId { get; set; }

    public int? MedEquipmentId { get; set; }

    public virtual MedEquipment? MedEquipment { get; set; }

    public virtual Ward? Ward { get; set; }
}
