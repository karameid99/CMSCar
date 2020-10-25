using CMSCar.Areas.CPanel.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Models.ViewModels
{
    public class OfferVM
    {
        public List<Car> Cars{ get; set; }
        public List<CarType> CarTypes { get; set; }
    }
}
