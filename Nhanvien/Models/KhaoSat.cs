using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class KhaoSat
{
    public int KhaosatId { get; set; }

    public string? TenTieuDe { get; set; }

    public int? TrangThai { get; set; }

    public DateTime? NgayBd { get; set; }

    public DateTime? NgayKt { get; set; }

    public virtual ICollection<CauHoi> CauHois { get; set; } = new List<CauHoi>();

    public virtual ICollection<NguoiThamGiaK> NguoiThamGiaKs { get; set; } = new List<NguoiThamGiaK>();
}
