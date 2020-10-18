using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class OfferDTO
    {
        public int Id { get; set; }
        [Display(Name = "اسم العرض بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "اسم العرض بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Display(Name = "وصف العرض بالعربية")]
        public string DescriptionAr { get; set; }
        [Display(Name = "وصف العرض بالانجليزية")]
        public string DescriptionEn { get; set; }
        [Display(Name = "صورة العرض")]
        public IFormFile Image { get; set; }
        [Display(Name = "السيارات المشمولة بالعرض")]
        public List<int> OfferCarIds { get; set; }
    }
}
