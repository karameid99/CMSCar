using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Models.ViewModels
{
    public class CarShowVM
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public float PriceBeforeDiscount { get; set; }
        public float PriceAfterDiscount { get; set; }
        public string ShowImage { get; set; }
    }
}
