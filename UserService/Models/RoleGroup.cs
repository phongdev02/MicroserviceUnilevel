using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class RoleGroup
    {
        [Key]
        public int rolegroupID { get; set; }
        public string rolegroupName { get; set; }
        public ICollection<Role> roles { get; set; } = new List<Role>();
    }
}
