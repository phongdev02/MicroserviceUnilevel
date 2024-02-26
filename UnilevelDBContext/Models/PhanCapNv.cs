using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class PhanCapNv
{
    public int NvId { get; set; }

    public int NvqlId { get; set; }

    public bool Trencap { get; set; }

    public virtual NhanVien Nv { get; set; } = null!;

    public virtual NhanVien Nvql { get; set; } = null!;
}
