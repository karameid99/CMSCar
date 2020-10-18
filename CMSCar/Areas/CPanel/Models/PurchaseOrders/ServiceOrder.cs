using CMSCar.Areas.CPanel.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.PurchaseOrders
{
    public class ServiceOrder : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string MeterReading { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public float Price { get; set; }
    }
}
