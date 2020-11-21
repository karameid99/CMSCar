using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.ViewModels
{
    public class ServiceOrderVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Model { get; set; }
        public string MeterReading { get; set; }
        public string ServiceName { get; set; }
        public float Price { get; set; }
        public string CreatedAt { get; set; }
    }
}
