using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CMSCar.Areas.CPanel.Controllers
{
    [Area("CPanel")]
    [Route("CPanel/[controller]/[action]")]
    [Route("CPanel/[controller]/[action]/{id?}")]
    [Authorize]
    public class BaseController :Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly ApplicationDbContext _Context;
        protected IMapper  _Mapper;
        protected string UserId;
        protected string UserName;

        public BaseController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _Context = context;
            _Mapper = mapper;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.Identity.IsAuthenticated)
            {
                base.OnActionExecuting(context);
                try
                {
                    UserId = _userManager.GetUserId(HttpContext.User);
                    ApplicationUser user = _Context.Users.FirstOrDefault(x => x.Id.Equals(UserId));
                    UserName = user.FullName;
                    ViewBag.UserImage = user.ImagePath == null ? "/Images/Default/default-user.png" : "/Images/User/" + user.ImagePath;
                    ViewBag.UserId = UserId;
                    ViewBag.UserEmail = user.UserName;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
