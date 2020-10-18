using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.PurchaseOrders
{
    public class CompanyCash : BaseEntity
    {
        [Required]
        public string NameCompany { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NamePerson { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<CarOrderCash> carOrders { get; set; }

    }
}
