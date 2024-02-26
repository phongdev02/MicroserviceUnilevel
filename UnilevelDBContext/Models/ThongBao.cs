using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class ThongBao
{
    public int ThongbaoId { get; set; }

    public string Noidung { get; set; } = null!;

    public bool ThongbaoHeThong { get; set; }

    public virtual ICollection<ThongBaoNv> ThongBaoNvs { get; set; } = new List<ThongBaoNv>();
}
