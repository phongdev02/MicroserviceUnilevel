﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace unilevel.Web.Models.Dto
{
    public class NhanvienDto : NhanvienDtoNoID
    {
        public int NvId { get; set; }
    }
}
