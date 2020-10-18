using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.PurchaseOrders
{
    public class CarOrderCash : BaseEntity
    {
        [Required]
        public string NameCar { get; set; }
        [Required]
        public int Count { get; set; }
        public int CompanyCashId { get; set; }
        public CompanyCash CompanyCash { get; set; }
    }
}
