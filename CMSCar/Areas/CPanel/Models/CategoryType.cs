using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models
{
    public enum CategoryType
    {
      
        [Display(Name = "موديل")]
        Second,
       [Display(Name = "تصنيف فرعي")]
        Firsr
    }
}
