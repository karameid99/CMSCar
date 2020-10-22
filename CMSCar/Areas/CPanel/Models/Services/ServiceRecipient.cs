using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Services
{
    public class ServiceRecipient :BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string Image { get; set; }
     
    }
}
