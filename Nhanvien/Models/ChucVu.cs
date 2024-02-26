using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class ChucVu
{
    public int ChucvuId { get; set; }

    public string TenCv { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public int NhomcvId { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual NhomChucVu Nhomcv { get; set; } = null!;

    public virtual ICollection<QuyenTruyCap> QuyenTruycaps { get; set; } = new List<QuyenTruyCap>();
}
