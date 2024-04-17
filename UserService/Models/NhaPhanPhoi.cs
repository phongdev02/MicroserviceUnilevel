using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class NhaPhanPhoi
    {
        [Key]
        public int nppID { get; set; }
        public string? tenNPP { get; set; }
        public string? email { get; set; }
        public string? Diachi { get; set; }
        public string? SDT { get; set; }
        public bool trangthai { get; set; } 
        [ForeignKey("KhuvucID")]
        public string KhuvucID { get; set; }                                                                                                                                                                                                                                                           
        public KhuVuc KhuVuc { get; set; }

        public virtual ICollection<Nhanvien> Nhanvien { get; set; } = new List<Nhanvien>();

    }
}
