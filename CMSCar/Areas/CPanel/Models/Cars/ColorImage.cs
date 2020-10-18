using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class ColorImage : BaseEntity
    {
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public int ColorCarId { get; set; }
        public ColorCar ColorCar { get; set; }
    }
}
