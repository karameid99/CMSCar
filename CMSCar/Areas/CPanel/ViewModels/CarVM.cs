﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.ViewModels
{
    public class CarVM
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public float PriceBeforeDiscount { get; set; }
        public float PriceAfterDiscount { get; set; }
        public string MainImage { get; set; }
        public string ShowImage { get; set; }
        public string CreateAt { get; set; }
    }
}
