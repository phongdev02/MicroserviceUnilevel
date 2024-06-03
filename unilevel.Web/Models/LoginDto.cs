using System.ComponentModel.DataAnnotations;

namespace unilevel.Web.Models
{
    public class LoginDto
    {
        [Required]
        public string gmail { get; set; }
        [Required]
        public string passwork { get; set; }
    }
}
