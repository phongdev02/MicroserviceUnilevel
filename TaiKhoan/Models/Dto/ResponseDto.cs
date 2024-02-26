namespace TaiKhoan.Models.Dto
{
    public class ResponseDto
    {
        public object? Resurt { get; set; }
        public bool? Success { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
