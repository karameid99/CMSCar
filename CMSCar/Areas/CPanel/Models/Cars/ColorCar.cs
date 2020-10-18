using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class ColorCar : BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }
        public List<ColorImage> colorImages { get; set; }

    }
}
