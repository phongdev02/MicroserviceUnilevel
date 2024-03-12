using System.ComponentModel.DataAnnotations;

namespace File.Models
{
    public class Tep
    {
        [Key]
        public int TepId { get; set; }
        public string TenTep { get; set; }
        public string KieuTep { get; set; }
        public byte[] DuLieu { get; set; } // Dữ liệu tệp được lưu dưới dạng mảng byte
        public DateTime NgayUpload { get; set; }
        public virtual ICollection<TepCu> tepCu { get; set; } = new List<TepCu>();
    }
}
