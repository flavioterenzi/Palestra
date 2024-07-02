using System;
using System.Collections.Generic;

namespace Palestra.Models;

public partial class Sale
{
    public int IdSala { get; set; }

    public string? NomeSala { get; set; }

    public int CapacitàMax { get; set; }

    public int? CorsiRif { get; set; }

    public virtual Corsi? CorsiRifNavigation { get; set; }

    public virtual ICollection<Personale> Personales { get; set; } = new List<Personale>();
}
