﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class ColorCarDTO
    {
        [Display(Name = "الأسم بالعربية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")] 
        public string NameAr { get; set; }
        [Display(Name = "الأسم بالانجليزية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Color { get; set; }
        public int CarId { get; set; }

    }
}
