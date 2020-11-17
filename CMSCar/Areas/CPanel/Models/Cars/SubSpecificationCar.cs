using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class SubSpecificationCar :BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        public string AnswerAr { get; set; }
        public string AnswerEn { get; set; }
        [Required]
        public int SpecificationCarId { get; set; }
        public SpecificationCar SpecificationCar { get; set; }
    }
}
