using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs.SubFS
{
    public class SubSpecificationCarDTO
    {
        [Display(Name = "اسم المواصفات بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "اسم المواصفات بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }

        public int SpecificationCarId { get; set; }
    }
}
