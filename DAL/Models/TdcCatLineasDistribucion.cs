using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TdcCatLineasDistribucion
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string CodLinea { get; set; } = null!;

    public string? CodProvincia { get; set; }

    public string? CodMunicipio { get; set; }

    public string? CodBarrio { get; set; }

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
