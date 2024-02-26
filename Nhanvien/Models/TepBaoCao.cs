using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class TepBaoCao
{
    public int TepbaocaoId { get; set; }

    public byte[]? TepBc { get; set; }

    public DateTime? NgayNhap { get; set; }

    public string? TenTep { get; set; }

    public virtual ICollection<NgoiThamGiaCv> NgoiThamGiaCvs { get; set; } = new List<NgoiThamGiaCv>();
}
