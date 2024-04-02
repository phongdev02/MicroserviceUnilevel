using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class NhaPhanPhoi
    {
        [Key]
        public int nppID { get; set; }
        public string NameNPP { get; set; }

        [ForeignKey("KhuvucID")]
        public string KhuvucID { get; set; }
        public KhuVuc KhuVuc { get; set; } = new KhuVuc();
    }
}
