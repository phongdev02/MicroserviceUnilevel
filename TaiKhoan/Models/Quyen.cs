using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaiKhoan.Models;

public partial class Quyen
{
    [Key]
    public int QuyenId { get; set; }

    public string TenQuyen { get; set; } = null!;

    public virtual ICollection<QuyenTruyCap> QuyenTruyCaps { get; set; } = new List<QuyenTruyCap>();
}
