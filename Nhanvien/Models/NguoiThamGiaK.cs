using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class NguoiThamGiaK
{
    public int NvId { get; set; }

    public int KhaosatId { get; set; }

    public int VaitroNguoiThamGia { get; set; }

    public virtual ICollection<KetQuaK> KetQuaKs { get; set; } = new List<KetQuaK>();

    public virtual KhaoSat Khaosat { get; set; } = null!;

    public virtual NhanVien Nv { get; set; } = null!;
}
