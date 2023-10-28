using System;
using System.Collections.Generic;

namespace DL;

public partial class Dona
{
    public int IdDona { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public string? Detalles { get; set; }

    public virtual ICollection<VentaDona> VentaDonas { get; set; } = new List<VentaDona>();
}
