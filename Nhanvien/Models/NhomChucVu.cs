using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class NhomChucVu
{
    public int NhomcvId { get; set; }

    public string? TenNcv { get; set; }

    public int? Quyen { get; set; }

    public virtual ICollection<ChucVu> ChucVus { get; set; } = new List<ChucVu>();
}
