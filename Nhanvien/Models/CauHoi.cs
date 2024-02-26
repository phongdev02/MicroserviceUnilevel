using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class CauHoi
{
    public int CauhoiId { get; set; }

    public string NoidungCh { get; set; } = null!;

    public bool NhieuLuaChon { get; set; }

    public int KhaosatId { get; set; }

    public virtual ICollection<DapAn> DapAns { get; set; } = new List<DapAn>();

    public virtual ICollection<KetQuaK> KetQuaKs { get; set; } = new List<KetQuaK>();

    public virtual KhaoSat Khaosat { get; set; } = null!;
}
