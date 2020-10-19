using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.PurchaseOrders
{
    public class CompanyFinance : BaseEntity
    {
        [Required]
        public string NameCompany { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NamePerson { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string CompanyActivity { get; set; }
        [Required]
        public int CompanyAge { get; set; }
        [Required]
        public int Bank { get; set; }
        public List<CarOrderFinance> carOrders { get; set; }

    }
}
