﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TdcCatLineasDistribucion
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string CodLinea { get; set; } = null!;

    public string CodProvincia { get; set; } = null!;

    public string CodMunicipio { get; set; } = null!;

    public string CodBarrio { get; set; } = null!;
}
