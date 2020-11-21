using CMSCar.Areas.CPanel.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Notfication
{
    public class Notifications
    {
        public Notifications()
        {
            SendAt = DateTime.Now;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime SendAt { get; set; }

        [ScaffoldColumn(false)]
        public bool IsRead { get; set; }
    }
}
