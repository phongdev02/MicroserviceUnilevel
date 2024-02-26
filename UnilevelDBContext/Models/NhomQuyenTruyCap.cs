using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class NhomQuyenTruyCap
{
    public int NhomQuyenId { get; set; }

    public string? TenNq { get; set; }

    public virtual ICollection<QuyenTruyCap> QuyenTruyCaps { get; set; } = new List<QuyenTruyCap>();
}
