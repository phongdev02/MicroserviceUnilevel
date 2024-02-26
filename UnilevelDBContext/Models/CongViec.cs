using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class CongViec
{
    public int CongviecId { get; set; }

    public string? TieudeCv { get; set; }

    public string? Mota { get; set; }

    public DateTime? NgayBd { get; set; }

    public DateTime? NgayKt { get; set; }

    public int? TrangThai { get; set; }

    public int? LichthamId { get; set; }

    public int? BinhluanId { get; set; }

    public virtual BinhLuan? Binhluan { get; set; }

    public virtual LichTham? Lichtham { get; set; }

    public virtual ICollection<NgoiThamGiaCv> NgoiThamGiaCvs { get; set; } = new List<NgoiThamGiaCv>();
}
