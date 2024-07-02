using System;
using System.Collections.Generic;

namespace Palestra.Models;

public partial class Persona
{
    public int IdPers { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
