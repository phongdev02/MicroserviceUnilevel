using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class Account
    {
        [Key]
        public int accId { get; set; }
  
        public string fullName { get; set; }
        public string email { get; set; }
        public string Password { get; set; }

        //link title
        public int titleID { get; set; }
        public Title title { get; set; }

        //link position
        //public Position position { get; set; }
        public bool status { get; set; }

        //link Account
        public int? managerID { get; set; }
        public Account account { get; set; }
        public ICollection<Account> accounts { get; set; }

        //link area
        public string? areaCode { get; set; }
        public Area area { get; set; }
    }
}
