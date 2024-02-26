using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class Quyen
{
    public int QuyenId { get; set; }

    public string TenQuyen { get; set; } = null!;

    public virtual ICollection<QuyenTruyCap> QuyenTruyCaps { get; set; } = new List<QuyenTruyCap>();
}
