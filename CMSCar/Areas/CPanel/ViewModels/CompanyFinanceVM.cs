﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.ViewModels
{
    public class CompanyFinanceVM
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string Email { get; set; }
        public string NamePerson { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string CompanyActivity { get; set; }
        public string CreateAt { get; set; }

    }
}
