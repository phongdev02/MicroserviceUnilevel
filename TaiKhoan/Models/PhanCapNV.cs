﻿using System.ComponentModel.DataAnnotations;

namespace TaiKhoan.Models
{
    public class PhanCapNV
    {
        [Key]
        public int id { get; set; }
        public int NvqlID { get; set; }
        public int NvID { get; set; }
        public bool Trangthai { get; set; }
    }
}
