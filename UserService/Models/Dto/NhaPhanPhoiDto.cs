using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models.Dto
{
    public class NhaPhanPhoiDto
    {
        public int nppID { get; set; }
        public string? tenNPP { get; set; }
        public string? email { get; set; }
        public string? Diachi { get; set; }
        public string? SDT { get; set; }
        public bool? trangthai { get; set; }
        public string? KhuvucID { get; set; }
    }
}
