using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class CarCategory
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int SubCarTypeId { get; set; }
        public SubCarType SubCarType { get; set; }
    }
}
