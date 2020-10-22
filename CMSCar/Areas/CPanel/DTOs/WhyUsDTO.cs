using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class WhyUsDTO
    {
        public int Id { get; set; }
        [Display(Name = "الأسم بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "الأسم بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Display(Name = "الوصف بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescrptionAr { get; set; }
        [Display(Name = "الوصف بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescrptionEn { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile Image { get; set; }
    }
}
