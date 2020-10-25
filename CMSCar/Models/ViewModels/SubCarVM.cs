using CMSCar.Areas.CPanel.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Models.ViewModels
{
    public class SubCarVM
    {
        public List<Car> Cars { get; set; }
        public List<SubCarType> CarTypes { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
    }
}
