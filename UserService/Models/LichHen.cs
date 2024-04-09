namespace UserService.Models
{
    public class LichHen
    {
        public int LichthamId { get; set; }

        public DateTime NgayTham { get; set; }

        public int Buoi { get; set; }

        public int Status { get; set; }

        public DateTime NhacNho { get; set; }

        public string Mota { get; set; } = null!;

        public int NguoiTao { get; set; }

        public int? nppID { get; set; }


        public virtual ICollection<CongViec> CongViecs { get; set; } = new List<CongViec>();

        public virtual Nhanvien Nhanven { get; set; } = null!;

        public virtual NhaPhanPhoi? NhaPhanPhoi { get; set; }

    }
}
