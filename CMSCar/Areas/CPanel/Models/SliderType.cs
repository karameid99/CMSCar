using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models
{
    public enum SliderType
    {
        [Display(Name = "الاول")]
        Firsr,
        [Display(Name = "الثاني")]
        Second,
        [Display(Name = "الثالث")]
        Third,
    }
}
