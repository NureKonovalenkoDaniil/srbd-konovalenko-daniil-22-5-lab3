using System;
using System.Collections.Generic;

namespace CardiologyApp.Models;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Preparation> Preparations { get; set; } = new List<Preparation>();
}
