using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Mails
{
    public class Mail : BaseEntity
    {
        [Required]
        public string Email { get; set; }
    }
}
