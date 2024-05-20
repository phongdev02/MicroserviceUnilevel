using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Dto
{
    public class AccountDto : AccountDtoNoID
    {
        public int accId { get; set; }
    }
}
