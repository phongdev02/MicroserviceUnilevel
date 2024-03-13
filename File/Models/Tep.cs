using System.ComponentModel.DataAnnotations;

namespace FileRetention.Models
{
    public class Tep
    {
        [Key]
        public int TepId { get; set; }
        public string TenTep { get; set; }
        public string KieuTep { get; set; }
        public byte[] DuLieu { get; set; } // Dữ liệu tệp được lưu dưới dạng mảng byte
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
        public virtual ICollection<TepCu> tepCu { get; set; } = new List<TepCu>();
    }
}
