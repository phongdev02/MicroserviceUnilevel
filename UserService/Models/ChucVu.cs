using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public partial class ChucVu
{
    [Key]
    public int ChucvuId { get; set; }

    public string TenCv { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public virtual ICollection<CapQuyen> CapQuyens { get; set; } = new List<CapQuyen>();
    public virtual ICollection<Nhanvien> Nhanvien { get; set; } = new List<Nhanvien>();
}
