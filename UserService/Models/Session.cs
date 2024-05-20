using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class Session
    {
        [Key]
        public int sesstionID { get; set; }
        public string sessionsName { get; set; }

    }
}
