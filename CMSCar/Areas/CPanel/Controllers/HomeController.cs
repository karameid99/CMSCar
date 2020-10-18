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

namespace CMSCar.Areas.CPanel.Controllers
{
    [Authorize(Roles = "Admin")]

    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
