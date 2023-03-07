using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class DlkCatAccEmpleado
{
    public string? MdUuid { get; set; }

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string? CodEmpleado { get; set; }

    public string? ClaveEmpleado { get; set; }

    public int? NivelAcceso { get; set; }

    public virtual DlkCatAccRole? NivelAccesoNavigation { get; set; }
}
