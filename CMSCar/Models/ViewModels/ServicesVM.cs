using CMSCar.Areas.CPanel.Models.FundingBodies;
using CMSCar.Areas.CPanel.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Models.ViewModels
{
    public class ServicesVM
    {
        public List<WhyUs> WhyUs { get; set; }
        public List<Service> services { get; set; }
    }
}
