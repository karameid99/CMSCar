using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Settings
{
    public class Titles :BaseEntity
    {
        public string WhyUSAr { get; set; }
        public string WhyUSEn { get; set; }
        public string OrderAr { get; set; }
        public string OrderEn { get; set; }
        public string OurPrice { get; set; }
        public string OurSponsers { get; set; }
    }
}
