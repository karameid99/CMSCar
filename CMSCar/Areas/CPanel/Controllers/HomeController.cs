using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMSCar.Areas.CPanel.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }

        public IActionResult Index()
        {
            var homeVm = new HomeVM
            {
                CarCount = _Context.Car.Count(),
                CallUsCount = _Context.CallUs.Count(),
                UserCount = _Context.Users.Count(),
                OrderCount = _Context.CompanyCash.Count() + _Context.IndividualCash.Count()
                + _Context.CompanyFinance.Count() + _Context.IndividualFinance.Count(),
            };
            return View(homeVm);
        }
    }
}
