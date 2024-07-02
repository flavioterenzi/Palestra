using System;
using System.Collections.Generic;

namespace Palestra.Models;

public partial class Corsi
{
    public int IdCorso { get; set; }

    public string NomeCorso { get; set; } = null!;

    public string? Descrizione { get; set; }

    public int? NumPartecipanti { get; set; }

    public virtual ICollection<Personale> Personales { get; set; } = new List<Personale>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
