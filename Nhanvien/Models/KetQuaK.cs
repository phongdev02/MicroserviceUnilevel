using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class KetQuaK
{
    public int KetquaId { get; set; }

    public int? NvId { get; set; }

    public int? KhaosatId { get; set; }

    public int? CauhoiId { get; set; }

    public virtual CauHoi? Cauhoi { get; set; }

    public virtual ICollection<DapAnK> DapAnKs { get; set; } = new List<DapAnK>();

    public virtual NguoiThamGiaK? NguoiThamGiaK { get; set; }
}
