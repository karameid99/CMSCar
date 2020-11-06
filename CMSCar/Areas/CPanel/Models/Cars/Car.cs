using CMSCar.Areas.CPanel.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class Car : BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public float PriceBeforeDiscount { get; set; }
        public float PriceAfterDiscount { get; set; }

        public string MainImage { get; set; }
        public string ShowImage { get; set; }


        public List<CarCategory> CarCategorys { get; set; }
        public List<ColorCar> ColorCars { get; set; }
        public List<FeatureCar> FeatureCars { get; set; }
        public List<SpecificationCar> SpecificationCars { get; set; }
        public List<CarImage> carImages { get; set; }
        public List<OfferCar> OfferCars { get; set; }

    }
}
