using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class DapAnK
{
    public int KetquaId { get; set; }

    public int DapanId { get; set; }

    public string? NoidungDakhac { get; set; }

    public virtual DapAn Dapan { get; set; } = null!;

    public virtual KetQuaK Ketqua { get; set; } = null!;
}
