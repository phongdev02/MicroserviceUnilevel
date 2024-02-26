using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class NhanVienPhuTrach
{
    public int NhaphanphoiId { get; set; }

    public int NvId { get; set; }

    public bool QuanLy { get; set; }

    public virtual NhaPhanPhoi Nhaphanphoi { get; set; } = null!;

    public virtual NhanVien Nv { get; set; } = null!;
}
