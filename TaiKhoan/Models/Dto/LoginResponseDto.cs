namespace TaiKhoan.Models.Dto
{
    public class LoginResponseDto
    {
        public NhanvienLoginDto Login { get; set; }
        public string token { get; set; }
    }
}
