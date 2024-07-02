using System;
using System.Collections.Generic;

namespace Palestra.Models;

public partial class Personale
{
    public int IdPersonale { get; set; }

    public string Nome { get; set; } = null!;

    public int? SalaRif { get; set; }

    public int? CorsiRif { get; set; }

    public virtual Corsi? CorsiRifNavigation { get; set; }

    public virtual Sale? SalaRifNavigation { get; set; }
}
