using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        [Display(Name = "اسم المدينة بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CityAr { get; set; }
        [Display(Name = " اسم المدينة بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CityEn { get; set; }
    }
}
