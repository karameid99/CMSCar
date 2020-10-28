using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        [Display(Name = "الأسم بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "الأسم بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Display(Name = "الوصف بالعربية")]
        public string DescriptionAr { get; set; }
        [Display(Name = "الوصف بالعربية")]
        public string DescriptionEn { get; set; }
        [Display(Name = "السعر بدون خصم")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public float PriceBeforeDiscount { get; set; }
        [Display(Name = "قيمة الخصم")]
        public float PriceAfterDiscount { get; set; }
        [Display(Name = "الصورة الرئيسية")]
        public IFormFile Main { get; set; }
        [Display(Name = "صورة العرض")]
        public IFormFile Show { get; set; }
        [Display(Name = "صور السيارة من الداخل")]
        public List<IFormFile> InsidImages { get; set; }
        [Display(Name = "النوع الفرعي")]
        public int SubCarTypeId { get; set; }
        public int CarTypeId { get; set; }
    }
}
