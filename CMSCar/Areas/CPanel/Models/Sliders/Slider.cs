using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Sliders
{
    public class Slider : BaseEntity
    {
        public string BackgroundImage { get; set; }
        public string BackgroundColor { get; set; }
        public string MainImage { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string SubTitleAr { get; set; }
        public string SubTitleEn { get; set; }
        public string LinkUrl { get; set; }
        public SliderType SliderType { get; set; }
        
    }
}
