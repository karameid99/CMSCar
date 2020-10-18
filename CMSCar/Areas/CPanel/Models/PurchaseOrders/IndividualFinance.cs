using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.PurchaseOrders
{
    public class IndividualFinance : IndividualCash
    {
        [Required]
        public float Salary { get; set; }
        [Required]
        public float Commitment { get; set; }
        public bool Loan { get; set; }
        [Required]
        public int FirstPay { get; set; }
        [Required]
        public int LastPay { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string WorkSector { get; set; }
        [Required]
        public int Bank { get; set; }
        [Required]
        public int licenseStatus { get; set; }

    }
}
