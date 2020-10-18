using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.PurchaseOrders
{
    public class IndividualCash : BaseEntity
    {
        [Required]
        public string CarName { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
