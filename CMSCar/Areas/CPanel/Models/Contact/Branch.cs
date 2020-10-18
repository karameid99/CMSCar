using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Contact
{
    public class Branch : BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        public string WorkingHoursAr { get; set; }
        public string WorkingHoursEn { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string MapLink { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
