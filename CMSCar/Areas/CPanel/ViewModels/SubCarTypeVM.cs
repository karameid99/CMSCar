using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.ViewModels
{
    public class SubCarTypeVM
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public CarTypeVM CarType { get; set; }
        public int CarTypeId { get; set; }
        public string CreateAt { get; set; }

    }
}
