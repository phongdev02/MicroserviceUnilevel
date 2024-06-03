namespace UserService.Models
{
    public class RoleTitle
    {
        public int roleId {get; set;}
        public Role role {get; set;}
        public int titleID {get; set;}
        public Title title {get; set;}
        public bool status {get; set;}
    }
}
