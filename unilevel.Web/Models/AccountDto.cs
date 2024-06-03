using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace unilevel.Web.Models
{
    public class AccountDto : AccountDtoNoID
    {
        public int accId { get; set; }
    }
}
