using System;
using System.Collections.Generic;

namespace DL;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int? IdCliente { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<VentaDona> VentaDonas { get; set; } = new List<VentaDona>();
}
