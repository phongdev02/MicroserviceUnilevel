using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Dto
{
    public class AccountDtoNoID
    {

        public string fullName { get; set; }
        public string email { get; set; }
        public string pass {  get; set; }
        public int titleID { get; set; }

        public bool status { get; set; }

        public int? managerID { get; set; }

        //link area
        public string? areaCode { get; set; }
    }
}
