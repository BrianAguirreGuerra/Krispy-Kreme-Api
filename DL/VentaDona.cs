using System;
using System.Collections.Generic;

namespace DL;

public partial class VentaDona
{
    public int IdVentaProducto { get; set; }

    public int? IdVenta { get; set; }

    public int? IdDona { get; set; }

    public int? Cantidad { get; set; }

    public virtual Dona? IdDonaNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}
