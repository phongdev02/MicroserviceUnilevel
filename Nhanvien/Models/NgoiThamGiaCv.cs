using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class NgoiThamGiaCv
{
    public int CongviecId { get; set; }

    public int NvId { get; set; }

    public int? Chucvu { get; set; }

    public int? TepbaocaoId { get; set; }

    public virtual CongViec Congviec { get; set; } = null!;

    public virtual NhanVien Nv { get; set; } = null!;

    public virtual TepBaoCao? Tepbaocao { get; set; }
}
