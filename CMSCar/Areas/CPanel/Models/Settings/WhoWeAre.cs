using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Settings
{
    public class WhoWeAre : BaseEntity
    {
        public string WhoWeAreAr { get; set; }
        public string WhoWeAreEn { get; set; }
        public string OurGoalsAr { get; set; }
        public string OurGoalsEn { get; set; }
        public string OurMassegeAr { get; set; }
        public string OurMassegeEn { get; set; }
        public string TermConditionAr { get; set; }
        public string TermConditionEn { get; set; }
        public string policyAr { get; set; }
        public string policyEn { get; set; }
    }
}
