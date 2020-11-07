using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class SpecificationCar : BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
        public string CarIdentfire { get; set; }

        public List<SubSpecificationCar> subSpecificationCars { get; set; }

    }
}
