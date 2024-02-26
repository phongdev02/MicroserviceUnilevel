using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class NhaPhanPhoi
{
    public int NhaphanphoiId { get; set; }

    public string TenNpp { get; set; } = null!;

    public string? Email { get; set; }

    public string? Diachi { get; set; }

    public string? Sdt { get; set; }

    public int? Trangthai { get; set; }

    public string KhuvucId { get; set; } = null!;

    public virtual KhuVuc Khuvuc { get; set; } = null!;

    public virtual ICollection<LichTham> LichThams { get; set; } = new List<LichTham>();

    public virtual ICollection<NhanVienPhuTrach> NhanVienPhuTraches { get; set; } = new List<NhanVienPhuTrach>();
}
