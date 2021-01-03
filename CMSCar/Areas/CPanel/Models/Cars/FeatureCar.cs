using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class FeatureCar : BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
        public string CarIdentfire { get; set; }
        [NotMapped]
        public bool isTake { get; set; }

        public List<SubFeatureCar> subFeatureCars { get; set; }
    }
}
