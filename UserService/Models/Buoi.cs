using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class Buoi
    {
        [Key]
        public int buoiID { get; set; }
        public string tenBuoi { get; set; }
        public virtual ICollection<ViengTham> ViengThams { get; set; }

    }
}
