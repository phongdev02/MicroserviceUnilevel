using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
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
