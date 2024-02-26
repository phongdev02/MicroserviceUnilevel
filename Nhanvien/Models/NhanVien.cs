using System;
using System.Collections.Generic;

namespace Nhanvien.Models;

public partial class NhanVien
{
    public int NvId { get; set; }

    public string? GmailNv { get; set; }

    public string? MatkhauNv { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? HoTen { get; set; }

    public DateTime? NgayLam { get; set; }

    public bool? TrangthaiNv { get; set; }

    public string? Sdt { get; set; }

    public int? ChucvuId { get; set; }

    public string? HinhanhNv { get; set; }

    public int? TkId { get; set; }

    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();

    public virtual ChucVu? Chucvu { get; set; }

    public virtual ICollection<LichTham> LichThams { get; set; } = new List<LichTham>();

    public virtual ICollection<NgoiThamGiaCv> NgoiThamGiaCvs { get; set; } = new List<NgoiThamGiaCv>();

    public virtual ICollection<NguoiThamGiaK> NguoiThamGiaKs { get; set; } = new List<NguoiThamGiaK>();

    public virtual ICollection<NhanVienPhuTrach> NhanVienPhuTraches { get; set; } = new List<NhanVienPhuTrach>();

    public virtual ICollection<PhanCapNv> PhanCapNvNvqls { get; set; } = new List<PhanCapNv>();

    public virtual ICollection<PhanCapNv> PhanCapNvNvs { get; set; } = new List<PhanCapNv>();

    public virtual ICollection<ThongBaoNv> ThongBaoNvs { get; set; } = new List<ThongBaoNv>();
}
