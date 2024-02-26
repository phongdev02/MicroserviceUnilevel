using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class BinhLuan
{
    public int BinhluanId { get; set; }

    public int SoSao { get; set; }

    public string? NoidungBl { get; set; }

    public virtual ICollection<CongViec> CongViecs { get; set; } = new List<CongViec>();
}
