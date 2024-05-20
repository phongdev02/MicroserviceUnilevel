using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class Distributor
    {
        [Key]
        public int disID { get; set; }
        public string? disName { get; set; }
        public string? disEmail { get; set; }
        public string? location { get; set; }
        public string? NumberPhone { get; set; }
        public bool status { get; set; } 
        [ForeignKey("KhuvucID")]
        public string areacode { get; set; }                                                                                                                                                                                                                                                           
        public Area area { get; set; }


    }
}
