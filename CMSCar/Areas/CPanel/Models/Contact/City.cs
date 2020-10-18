using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Contact
{
    public class City :BaseEntity
    {
        [Required]
        public string CityAr { get; set; }
        [Required]
        public string CityEn { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
