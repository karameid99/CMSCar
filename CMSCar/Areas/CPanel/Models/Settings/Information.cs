using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Models.Settings
{
    public class Information : BaseEntity
    {
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string SnapchatUrl { get; set; }
        public string WhatsappNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Logo { get; set; }
        public string SmallLogo{ get; set; }
    }
}
