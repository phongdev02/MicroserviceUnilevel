using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class LichTham
{
    public int LichthamId { get; set; }

    public DateTime NgayTham { get; set; }

    public int Buoi { get; set; }

    public int Status { get; set; }

    public DateTime NhacNho { get; set; }

    public string Mota { get; set; } = null!;

    public int NguoiTao { get; set; }

    public int? Nhaphanphoi { get; set; }

    public virtual ICollection<CongViec> CongViecs { get; set; } = new List<CongViec>();

    public virtual NhanVien NguoiTaoNavigation { get; set; } = null!;

    public virtual NhaPhanPhoi? NhaphanphoiNavigation { get; set; }
}
