using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.DTOs
{
    public class FininceSideDTO
    {
        public int Id { get; set; }
        [Display(Name = "اسم جهة التمويل بالعربية")]
        public string NameAr { get; set; }
        [Display(Name = "اسم جهة التمويل بالعربية")]
        public string NameEn { get; set; }
        [Display(Name = "شعار جهة التمويل ")]
        public IFormFile Image { get; set; }
    }
}
