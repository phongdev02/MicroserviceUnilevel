using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChucvuPhanquyen.Models;

namespace ChucvuPhanquyen.Models;

public partial class QuyenTruyCap
{
    [Key]
    public int QuyenTruycapId { get; set; }

    public string? TenQuyenTc { get; set; }

    public int? QuyenId { get; set; }

    public int? NhomQuyenId { get; set; }

    public virtual NhomQuyenTruyCap? NhomQuyen { get; set; }

    public virtual Quyen? Quyen { get; set; }

    public virtual ICollection<CapQuyen> CapQuyens { get; set; } = new List<CapQuyen>();
}
