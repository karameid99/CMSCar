using CMSCar.Areas.CPanel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class SliderDTO
    {
        public int Id { get; set; }
        [Display(Name = "الصورة الرئيسية ")]
        public IFormFile MainImages { get; set; }
        [Display(Name = "الصورة الاولى ")]
        public IFormFile Images1 { get; set; }
        [Display(Name = "الصورة الثانية ")]
        public IFormFile Images2 { get; set; }
        [Display(Name = "الصورة الثالثة ")]
        public IFormFile Images3 { get; set; }
        [Display(Name = "الصورة الرابعة ")]
        public IFormFile Images4 { get; set; }
        [Display(Name = "العنوان الرئيسي بالعربية")]
        public string TitleAr { get; set; }
        [Display(Name = "العنوان الرئيسي بالانجليزية")]
        public string TitleEn { get; set; }
        [Display(Name = "العنوان الفرعي بالعربية")]
        public string SubTitleAr { get; set; }
        [Display(Name = "العنوان الفرعي بالانجليزية")]
        public string SubTitleEn { get; set; }
        [Display(Name = "لون الخلفية")]
        public string BackgroundColor { get; set; }
        [Display(Name = "  رابط التوجيه")]
        public string LinkUrl { get; set; }
        [Display(Name = "نموذج المنشور")]
        public SliderType SliderType { get; set; }
    }
}
