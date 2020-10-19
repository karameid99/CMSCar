using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.ViewModels
{
    public class QuestionVM
    {
        public int Id { get; set; }
        public string QuestionAr { get; set; }
        public string QuestionEn { get; set; }
        public string CreateAt { get; set; }
    }
}
