using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public partial class NhomQuyenTruyCap
{
    [Key]
    public int NhomQuyenId { get; set; }

    public string? TenNq { get; set; }

    public virtual ICollection<QuyenTruyCap> QuyenTruyCaps { get; set; } = new List<QuyenTruyCap>();
}
