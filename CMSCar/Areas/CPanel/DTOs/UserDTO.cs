using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class UserDTO
    {
        [Display(Name = "اسم الشخص كامل")]
        [Required(ErrorMessage ="يرجى إدخال الاسم كاملا")]
        public string FullName { get; set; }

        [Display(Name = "البريد الالكتروني")]
        [Required(ErrorMessage = "يرجى إدخال البريد الالكتروني")]
        public string Email { get; set; }

        [Display(Name = "رقم الجوال")]
        [Required(ErrorMessage = "يرجى إدخال رقم الجوال")]
        public string PhoneNumber { get; set; }

        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Display(Name = "الصورة الشخصية")]
        public IFormFile Image { get; set; }
    }
}
