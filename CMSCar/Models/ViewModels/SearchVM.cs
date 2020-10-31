using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Models.ViewModels
{
    public class SearchVM
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string SearchKey { get; set; }
    }
}
