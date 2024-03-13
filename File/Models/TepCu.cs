using System.ComponentModel.DataAnnotations;

namespace FileRetention.Models
{
    // khi chỉnh xửa tệp hay file thì sẽ lưu lại ở đây để tạo điều kiện backup
    public class TepCu
    {
        [Key]
        public int TepcuId { get; set; }
        public int TenTep { get; set; }
        public byte[] Dulieu { get; set; }
        public DateTime NgayChinhXua { get; set; }
        public string TacDong { get; set; }
        public bool TrangThai { get; set; }
        public int TepID { get; set; }
        public Tep Tep { get; set; }
    }
}
