using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class HistoryPreparation
{
    public int HistoryPreparationId { get; set; }

    public int? HistoryId { get; set; }

    public int? PreparationId { get; set; }

    public virtual History? History { get; set; }

    public virtual Preparation? Preparation { get; set; }
}
