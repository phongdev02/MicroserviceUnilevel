using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class Area
    {
        [Key]
        public string areaCode { get; set; }
        public string areaName { get; set; }
        public bool status { get; set; }
        public virtual ICollection<Account> accounts { get; set; }
        public virtual ICollection<Distributor> distributors { get; set; }
    }
}
