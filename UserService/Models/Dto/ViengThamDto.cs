using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models.Dto
{
    public class ViengThamDto
    {
        public int viengThamID { get; set; }

        public DateTime NgayThucHien { get; set; }
        public DateTime NgayTao { get; set; }

        public int buoiID { get; set; }

        public int Status { get; set; }

        public DateTime? NhacNho { get; set; }

        public string? Mota { get; set; }

    }
}
