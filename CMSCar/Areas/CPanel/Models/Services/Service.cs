using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Services
{
    public class Service : BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        public string DescrptionAr { get; set; }
        public string DescrptionEn { get; set; }
        public float PriceBeforeDiscount { get; set; }
        public float PriceAfterDiscount { get; set; }
    }
}
