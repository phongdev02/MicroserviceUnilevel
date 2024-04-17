using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace unilevel.Web.Models
{
    public class NhanvienDtoNoID
    {
        public string? GmailNv { get; set; }
        public string GmailQuanly { get; set; }
        public string MatkhauNv { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? HoTen { get; set; }
        public string? Diachi { get; set; }
        public DateTime? NgayLam { get; set; }
        public bool TrangthaiNv { get; set; }
        public string? Sdt { get; set; }
        public int? ChucvuId { get; set; }
        public int? HinhanhID { get; set; }
    }
}
