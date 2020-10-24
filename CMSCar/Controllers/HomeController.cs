using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMSCar.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using CMSCar.Data;
using CMSCar.Models.ViewModels;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.Settings;
using CMSCar.Areas.CPanel.Models.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using CMSCar.Areas.CPanel.Models.Contact;

namespace CMSCar.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _Mapper;

        public HomeController(ApplicationDbContext context , ILogger<HomeController> logger , IMapper mapper) : base(context)
        {
            _logger = logger;
            _Mapper = mapper;
        }

        public IActionResult Index()
        {
            var Titles = _Context.Titles.FirstOrDefault();
            var defaultObj = new Titles
            {
                WhyUSAr = " ",
                WhyUSEn = " ",
                OrderAr = " ",
                OrderEn = " ",
                OurPrice = " ",
                OurSponsers = " ",
                          };
            ViewData["Titles"] = Titles == null ? defaultObj : Titles;
            IndexVM index = new IndexVM();
            index.Cars = _Mapper.Map<List<CarShowVM>>(_Context.Car.ToList());
            return View(index);
        }

        public IActionResult Qustion()
        {
           var items =  _Context.Question.ToList();
            return View(items);
        }
        public IActionResult Contact()
        {
            var items = _Context.City.Include(x => x.Branches).ToList();
            return View(items);
        }
        [HttpPost]
        public IActionResult Contact(CallUs call)
        {
            if (ModelState.IsValid)
            {
                _Context.CallUs.Add(call);
                _Context.SaveChanges();
                TempData["EditStatus"] = "Done";
            }
            return RedirectToAction("Contact");
        }
        public IActionResult Branche(int branchId)
        {
            var item = _Context.Branch.Find(branchId);
            return Json(item);
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true,  //critical settings to apply new culture
                    Path = "/",
                    HttpOnly = false,
                }
            );

            return LocalRedirect(returnUrl);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult CompanyOrder()
        {
            return View();
        }

        public IActionResult SuccessOrder()
        {
            return View();
        }

        public IActionResult IndiviualOrder()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult ICash(IndividualCash cash)
        {
            if (ModelState.IsValid)
            {
                _Context.IndividualCash.Add(cash);
                _Context.SaveChanges();
                return RedirectToAction("SuccessOrder");
            }
            ViewData["EditStatus"] = "Error";
            return RedirectToAction("IndiviualOrder");
        }

    }
}
