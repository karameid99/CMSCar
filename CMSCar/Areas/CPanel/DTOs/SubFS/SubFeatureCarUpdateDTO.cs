using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs.SubFS
{
    public class SubFeatureCarUpdateDTO
    {
        [Display(Name = "اسم المواصفات بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Display(Name = "اسم المواصفات بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Display(Name = "الاجابة بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AnswerAr { get; set; }
        [Display(Name = "الاجابة بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AnswerEn { get; set; }
        public int Id { get; set; }
    }
}
