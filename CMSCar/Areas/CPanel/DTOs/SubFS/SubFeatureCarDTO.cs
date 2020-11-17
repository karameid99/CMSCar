using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs.SubFS
{
    public class SubFeatureCarDTO
    {
        [Display(Name = "اسم الميزة بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "اسم الميزة بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
      
        public int FeatureCarId { get; set; }
    }
}
