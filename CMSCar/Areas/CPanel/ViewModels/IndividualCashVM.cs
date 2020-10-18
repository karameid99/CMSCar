using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.ViewModels
{
    public class IndividualCashVM
    {
        public int Id{ get; set; }
        public string CarName { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CreateAt { get; set; }
    }
}
