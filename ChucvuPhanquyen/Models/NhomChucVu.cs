using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChucvuPhanquyen.Models;

namespace ChucvuPhanquyen.Models;

public partial class NhomChucVu
{
    [Key]
    public int NhomcvId { get; set; }

    public string? TenNcv { get; set; }

    public int? Quyen { get; set; }

    public virtual ICollection<ChucVu> ChucVus { get; set; } = new List<ChucVu>();
}
