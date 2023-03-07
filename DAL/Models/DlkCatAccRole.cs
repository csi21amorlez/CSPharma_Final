using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class DlkCatAccRole
{
    public int Id { get; set; }

    public string DescRol { get; set; } = null!;

    public virtual ICollection<DlkCatAccEmpleado> DlkCatAccEmpleados { get; } = new List<DlkCatAccEmpleado>();
}
