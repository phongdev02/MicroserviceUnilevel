using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaiKhoan.Models
{
    [Table("CapQuyen")]
    public class CapQuyen
    {
        public int QuyenTruycapId { get; set; }

        public QuyenTruyCap QuyenTruyCap { get; set; }


        public int ChucvuId { get; set; }

        public ChucVu ChucVu { get; set; }


    }
}
