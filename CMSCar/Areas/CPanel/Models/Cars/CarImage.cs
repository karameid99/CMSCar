using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class CarImage :BaseEntity
    {
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
