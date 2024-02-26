using System;
using System.Collections.Generic;

namespace UnilevelDBContext.Models;

public partial class KhuVuc
{
    public string KhuvucId { get; set; } = null!;

    public string TenKv { get; set; } = null!;

    public virtual ICollection<NhaPhanPhoi> NhaPhanPhois { get; set; } = new List<NhaPhanPhoi>();
}
