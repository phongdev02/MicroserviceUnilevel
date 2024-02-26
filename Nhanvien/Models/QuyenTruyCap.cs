using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class QuyenTruyCap
{
    public int QuyenTruycapId { get; set; }

    public string? TenQuyenTc { get; set; }

    public int? QuyenId { get; set; }

    public int? NhomQuyenId { get; set; }

    public virtual NhomQuyenTruyCap? NhomQuyen { get; set; }

    public virtual Quyen? Quyen { get; set; }

    public virtual ICollection<ChucVu> Chucvus { get; set; } = new List<ChucVu>();
}
