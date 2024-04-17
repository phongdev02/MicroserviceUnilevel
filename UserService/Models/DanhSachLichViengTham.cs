namespace UserService.Models
{
    public class DanhSachLichViengTham
    {
        public int viengthamID { get; set; }
        public ViengTham ViengTham { get; set; }
        public int taikhoanID { get; set; }
        public Nhanvien Nhanvien { get; set; }
        public bool NguoiTao { get; set; }
        public bool TrangThaiThamDu { get; set; }
    }
}
