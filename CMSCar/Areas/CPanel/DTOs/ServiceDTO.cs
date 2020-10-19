using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        [Display(Name = "اسم الخدمة بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "اسم الخدمة بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Display(Name = "وصف الخدمة بالعربية")]
        public string DescrptionAr { get; set; }
        [Display(Name = "اوصف الخدمة بالانجليزية")]
        public string DescrptionEn { get; set; }
        [Display(Name = "سعر الخدمة دون خصم")]
        public float PriceBeforeDiscount { get; set; }
        [Display(Name = "سعر الخدمة بعد الخصم")]
        public float PriceAfterDiscount { get; set; }
    }
}
