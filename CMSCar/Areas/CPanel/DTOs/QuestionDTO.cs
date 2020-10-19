using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        [Display(Name = "السؤال بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")] 
        public string QuestionAr { get; set; }
        [Display(Name = "السؤال بالأنجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")] 
        public string QuestionEn { get; set; }
        [Display(Name = "الإجابة بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AnswerAr { get; set; }
        [Display(Name = "الإجابة بالأنجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")] 
        public string AnswerEn { get; set; }
    }
}
