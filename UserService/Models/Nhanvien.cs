using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class Nhanvien
    {
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
        public bool trangThaiTaiKhoan { get; set; }
        public string? Sdt { get; set; }
        public bool? nguoidung { get; set; }
        [ForeignKey("ChucvuId")]
        public int? ChucvuId { get; set; }
        public ChucVu? ChucVu { get; set; }

        [ForeignKey("nppID")]
        public int nppID { get; set; }
        public NhaPhanPhoi nhaPhanPhoi { get; set; }
        public bool? quanlyNPP { get; set; }
        public int? HinhanhID { get; set; }
    }
}
