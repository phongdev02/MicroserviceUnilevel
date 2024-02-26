using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class DapAn
{
    public int DapanId { get; set; }

    public string? NoidungDa { get; set; }

    public string? Hinhanh { get; set; }

    public int CauhoiId { get; set; }

    public bool DapanKhac { get; set; }

    public virtual CauHoi Cauhoi { get; set; } = null!;

    public virtual ICollection<DapAnK> DapAnKs { get; set; } = new List<DapAnK>();
}
