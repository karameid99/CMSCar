using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class BranchUpdateDTO
    {
        public int Id { get; set; }
        [Display(Name = "الأسم بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "الأسم بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Display(Name = "ساعات العمل بالعربية")]
        public string WorkingHoursAr { get; set; }
        [Display(Name = "ساعات العمل بالانجليزية")]
        public string WorkingHoursEn { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }
        [Display(Name = "رقم الواتساب")]
        public string WhatsappNumber { get; set; }
        [Display(Name = "رابط المكان على جوجل  ")]
        public string MapLink { get; set; }
        public int CityId { get; set; }
    }
}
