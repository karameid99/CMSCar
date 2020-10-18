using CMSCar.Areas.CPanel.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.SpecialOffers
{
    public class OfferCar
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
