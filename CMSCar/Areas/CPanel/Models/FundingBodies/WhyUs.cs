using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.FundingBodies
{
    public class WhyUs : BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string DescrptionAr { get; set; }
        public string DescrptionEn { get; set; }
        public string ImagePath { get; set; }
        public int OrderBy { get; set; }
    }
}
