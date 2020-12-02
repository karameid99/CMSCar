using CMSCar.Areas.CPanel.Models.Sliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Models.ViewModels
{
    public class IndexVM
    {
        public List<CarShowVM> Cars { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<FixedSlider> FixedSliders { get; set; }
    }
}
