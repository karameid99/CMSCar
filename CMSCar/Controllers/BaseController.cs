using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCar.Areas.CPanel.Models.Settings;
using CMSCar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CMSCar.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _Context;
        public BaseController(ApplicationDbContext context)
        {
            _Context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ObjInfo = _Context.Information.FirstOrDefault();
            var defaultObj = new Information
            {
                FacebookUrl = " ",
                TwitterUrl = " ",
                LinkedInUrl = " ",
                YoutubeUrl = " ",
                SnapchatUrl = " ",
                InstagramUrl = " ",
                WhatsappNumber = " ",
                PhoneNumber = " ",
                Logo = " ",
                SmallLogo = " ",
               };

            ViewData["Info"] = ObjInfo == null ? defaultObj : ObjInfo;
        }
    }
}
