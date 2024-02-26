using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class ThuVien
{
    public int ThuvienId { get; set; }

    public byte[]? Tep { get; set; }

    public string? Ten { get; set; }

    public DateTime? NgayNhap { get; set; }

    public string? DuongDan { get; set; }

    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();
}
