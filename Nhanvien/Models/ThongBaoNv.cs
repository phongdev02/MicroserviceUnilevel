using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class ThongBaoNv
{
    public int ThongbaoId { get; set; }

    public int NvId { get; set; }

    public bool Trangthai { get; set; }

    public virtual NhanVien Nv { get; set; } = null!;

    public virtual ThongBao Thongbao { get; set; } = null!;
}
