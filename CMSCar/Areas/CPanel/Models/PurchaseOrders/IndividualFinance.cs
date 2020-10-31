using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.PurchaseOrders
{
    public class IndividualFinance : BaseEntity
    {
        [Required]
        public string CarName { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public float Commitment { get; set; }
        public bool Loan { get; set; }
        [Required]
        public string FirstPay { get; set; }
        [Required]
        public string LastPay { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string WorkSector { get; set; }
        [Required]
        public string Bank { get; set; }
        public string licenseStatus { get; set; }

    }
}
