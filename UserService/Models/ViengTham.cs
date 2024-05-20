using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class ViengTham
    {
        [Key]
        public int viengThamID { get; set; }

        [ForeignKey("buoiID")]
        public int buoiID { get; set; } 
        public Session buois { get; set; } = new Session();

        public int Status { get; set; }

        public DateTime? NhacNho { get; set; }

        public string? Mota { get; set; } = null!;

        public DateTime NgayThucHien { get; set; }
        public DateTime NgayTao { get; set; }
        public virtual ICollection<DanhSachLichViengTham> DanhSachLichViengThams { get; set; }

    }
}
