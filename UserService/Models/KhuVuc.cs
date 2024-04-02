using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class KhuVuc
    {
        [Key]
        public string KhuvucCode { get; set; }
        public string TenKhuvuc { get; set; }
        public bool? Trangthai { get; set; }
        public virtual ICollection<NhaPhanPhoi> NhaPhanPhois { get; set; }
    }
}
