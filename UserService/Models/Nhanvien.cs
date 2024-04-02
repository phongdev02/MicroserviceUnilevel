using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class Nhanvien
    {
        public Nhanvien() { }

        [Key]
        public int NvId { get; set; }

        public string? GmailDangnhap { get; set; }

        public string? GmailNv { get; set; }
        [Required]
        public string GmailQuanly { get; set; }

        public string MatkhauNv { get; set; }

        public DateTime? NgayTao { get; set; }

        public string? HoTen { get; set; }
        public string? Diachi { get; set; }
        public DateTime? NgayLam { get; set; }

        [Required]
        public bool TrangthaiNv { get; set; }
        [Required]
        public string? Sdt { get; set; }

        [ForeignKey("ChucvuId")]
        public int? ChucvuId { get; set; }
        public ChucVu? ChucVu { get; set; }

        public int? HinhanhID { get; set; }
    }
}
