using System.ComponentModel.DataAnnotations;

namespace ChucvuPhanquyen.Models
{
    public class PhanCapNV
    {
        [Key] 
        public int id { get; set; }
        [Required]
        public int NvqlID { get; set; }
        [Required]
        public int NvID { get; set; }
        [Required]
        public bool Trangthai { get; set; }
    }
}
