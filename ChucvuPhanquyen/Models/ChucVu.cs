using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChucvuPhanquyen.Models;

public partial class ChucVu
{
    [Key]
    public int ChucvuId { get; set; }

    public string TenCv { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public int NhomcvId { get; set; }

    public virtual NhomChucVu Nhomcv { get; set; } = null!;

    public virtual ICollection<CapQuyen> CapQuyens{ get; set; } = new List<CapQuyen>();
}
