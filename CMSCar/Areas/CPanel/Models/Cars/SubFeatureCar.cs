using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Cars
{
    public class SubFeatureCar : BaseEntity
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string AnswerAr { get; set; }
        [Required]
        public string AnswerEn { get; set; }
        [Required]
        public int FeatureCarId { get; set; }
        public FeatureCar FeatureCar { get; set; }

    }
}
