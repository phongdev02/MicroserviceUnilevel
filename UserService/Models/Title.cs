namespace UserService.Models
{
    public class Title
    {
        public int titleID { get; set; }
        public String titleName { get; set; }
        public ICollection<Account> accounts { get; set; }
        public ICollection<RoleTitle> roleTitles { get; set; }
    }
}
