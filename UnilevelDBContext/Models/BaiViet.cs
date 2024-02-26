using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class BaiViet
{
    public int BaivietId { get; set; }

    public string? TieuDe { get; set; }

    public string? Mota { get; set; }

    public DateTime? Ngaytao { get; set; }

    public int? Trangthai { get; set; }

    public int? ThuvienId { get; set; }

    public string? DuongDan { get; set; }

    public int? NnvId { get; set; }

    public virtual NhanVien? Nnv { get; set; }

    public virtual ThuVien? Thuvien { get; set; }
}
