using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Dto
{
    public class LoginDto
    {
        [Required]
        public string gmail { get; set;}
        [Required]
        public string passwork { get; set; }
    }
}
