using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class Role
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }
        public int rolegroupID { get; set; }
        public RoleGroup roleGroup { get; set; }
        public ICollection<RoleTitle> roleTitles { get; set; }
    }
}
