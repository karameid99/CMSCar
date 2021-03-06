﻿using System;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models;
using CMSCar.Areas.CPanel.Models.Notfication;
using CMSCar.Areas.CPanel.Models.Mails;

namespace CMSCar.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _Mapper;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger, IMapper mapper) : base(context)
        {
            _logger = logger;
            _Mapper = mapper;
        }
        public IActionResult Privacy()
        {
            _Context.FixedSlider.Add(new Areas.CPanel.Models.Sliders.FixedSlider { FixedSliders = FixedSlider.Faive });
            _Context.SaveChanges();
            return View();
        }
        public IActionResult Index()
        {
            ViewData["Brands"] = new SelectList(_Context.CarType, "Id", "NameAr");
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
            index.Sliders = _Context.Slider.OrderByDescending(x => x.CreatedAt).ToList();
            index.FixedSliders = _Context.FixedSlider.Where(x => x.IsActive).OrderByDescending(x => x.CreatedAt).ToList();
            index.Cities = _Context.City.Include(x => x.Branches).ToList();
            return View(index);
        }

        public IActionResult Qustion()
        {
            var items = _Context.Question.ToList();
            return View(items);
        }
        public IActionResult BuyService()
        {
            ViewData["Services"] = new SelectList(_Context.Service, "Id", "NameAr");
            return View();
        }
        public IActionResult Contact()
        {
            var items = _Context.City.Include(x => x.Branches).ToList();
            return View(items);
        }
        public IActionResult Services()
        {
            ServicesVM vm = new ServicesVM();
            vm.WhyUs = _Context.WhyUs.ToList();
            vm.services = _Context.Service.ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Contact(CallUs call)
        {
            if (ModelState.IsValid)
            {
                _Context.CallUs.Add(call);
                var not = new Notifications
                {
                    Title = "هناك طلب تواصل جديد من " + call.Name,
                    Body = "يرجى الاطلاع على طلب التواصل في لوحة التحكم",
                    IsRead = false,
                    NotficationType = NotficationType.Contact,
                    NotficationLink = "/CPanel/CallUs/Index"

                };
                _Context.Notifications.Add(not);
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



        public IActionResult CompaniesOrder()
        {
            return View();
        }

        public IActionResult SuccessOrder()
        {
            return View();
        }

        public IActionResult IndiviualOrder(int? id)
        {
            var car = _Context.Car.Find(id);
            if (car == null)
            {
                return View();
            }
            var poc = new POCarVM
            {
                NameAr = car.NameAr,
                NameEn = car.NameEn,
                Price = car.PriceAfterDiscount == 0 ? car.PriceBeforeDiscount + "" : car.PriceAfterDiscount + ""
            };
            return View(poc);

        }

        [HttpPost]
        public IActionResult ICash(IndividualCash cash)
        {
            if (ModelState.IsValid)
            {
                _Context.IndividualCash.Add(cash);
                var not = new Notifications
                {
                    Title = "هناك طلب شراء(كاش افراد) جديد من " + cash.Name,
                    Body = "يرجى الاطلاع على طلب الشراء في لوحة التحكم",
                    IsRead = false,
                    NotficationType = NotficationType.CashIndiviual,
                    NotficationLink = "/CPanel/Indiviual/CashIndex"


                };
                _Context.Notifications.Add(not);
                _Context.SaveChanges();
                return RedirectToAction("SuccessOrder");
            }
            ViewData["EditStatus"] = "Error";
            return RedirectToAction("IndiviualOrder");
        }

        [HttpPost]
        public IActionResult CreateServiceOrder(ServiceOrder serviceOrder)
        {
            if (ModelState.IsValid)
            {
                _Context.ServiceOrder.Add(serviceOrder);
                var not = new Notifications
                {
                    Title = "هناك طلب شراء(خدمة) جديد من " + serviceOrder.Name,
                    Body = "يرجى الاطلاع على طلب شراء الخدمة في لوحة التحكم",
                    IsRead = false,
                    NotficationType = NotficationType.BuyService,
                    NotficationLink = "/CPanel/ServiceOrder/Index"


                };
                _Context.Notifications.Add(not);
                _Context.SaveChanges();

                return RedirectToAction("SuccessOrder");
            }

            ViewData["EditStatus"] = "Error";
            return RedirectToAction("BuyService");
        }

        [HttpPost]
        public IActionResult CCash(CompanyCash cash, string[] cars, int[] quantity)
        {
            if (ModelState.IsValid)
            {

                _Context.CompanyCash.Add(cash);
                _Context.SaveChanges();
                if (cars != null && quantity != null)
                {
                    for (int i = 0; i < cars.Count(); i++)
                    {
                        var carOrder = new CarOrderCash
                        {
                            Count = quantity[i],
                            NameCar = cars[i],
                            CompanyCashId = cash.Id
                        };
                        _Context.CarOrderCash.Add(carOrder);
                    }
                    _Context.SaveChanges();

                }
                var not = new Notifications
                {
                    Title = "هناك طلب شراء(كاش شركات) جديد من " + cash.NameCompany,
                    Body = "يرجى الاطلاع على طلب شراء الشركة في لوحة التحكم",
                    IsRead = false,
                    NotficationType = NotficationType.CashCompany,
                    NotficationLink = "/CPanel/Company/CashIndex"

                };
                _Context.Notifications.Add(not);
                _Context.SaveChanges();
                return RedirectToAction("SuccessOrder");
            }
            ViewData["EditStatus"] = "Error";
            return RedirectToAction("IndiviualOrder");
        }
        [HttpPost]
        public IActionResult CFinice(CompanyFinance cash, string[] cars, int[] quantity)
        {
            if (ModelState.IsValid)
            {
                _Context.CompanyFinance.Add(cash);
                _Context.SaveChanges();
                if (cars != null && quantity != null)
                {
                    for (int i = 0; i < cars.Count(); i++)
                    {
                        var carOrder = new CarOrderFinance
                        {
                            Count = quantity[i],
                            NameCar = cars[i],
                            CompanyFinanceId = cash.Id
                        };
                        _Context.CarOrderFinance.Add(carOrder);
                    }
                    _Context.SaveChanges();

                }
                var not = new Notifications
                {
                    Title = "هناك طلب شراء(تمويل شركات) جديد من " + cash.NameCompany,
                    Body = "يرجى الاطلاع على طلب شراء الشركة في لوحة التحكم",
                    IsRead = false,
                    NotficationType = NotficationType.FininceCompany,
                    NotficationLink = "/CPanel/Company/FinanceIndex"

                };
                _Context.Notifications.Add(not);
                _Context.SaveChanges();
                return RedirectToAction("SuccessOrder");
            }
            ViewData["EditStatus"] = "Error";
            return RedirectToAction("IndiviualOrder");
        }
        public IActionResult IndviuialFinance(IndividualFinance Finance)
        {

            _Context.IndividualFinance.Add(Finance);
            _Context.SaveChanges();
            var not = new Notifications
            {
                Title = "هناك طلب شراء(تمويل افراد) جديد من " + Finance.Name,
                Body = "يرجى الاطلاع على طلب شراء الفرد في لوحة التحكم",
                IsRead = false,
                NotficationType = NotficationType.FininceIndiviual,
                NotficationLink = "/CPanel/Indiviual/FinanceIndex"

            };
            _Context.Notifications.Add(not);
            _Context.SaveChanges();
            ViewData["EditStatus"] = "Error";
            return RedirectToAction("SuccessOrder");

        }
        [HttpPost]
        public IActionResult Email(Mail mail)
        {
            _Context.Mail.Add(mail);
            _Context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Search(SearchVM searchVM)
        {

            var result = _Context.Car.Include(x => x.CarCategorys).ThenInclude(c => c.SubCarType).ThenInclude(x => x.CarType).Where(z => (z.CarCategorys.Any(x => x.SubCarType.CarTypeId == searchVM.BrandId) ||
             !searchVM.BrandId.HasValue) &&
             (z.CarCategorys.Any(x => x.SubCarType.Id == searchVM.TypeId) || !searchVM.TypeId.HasValue) &&
             (z.CarCategorys.Any(x => x.SubCarType.Id == searchVM.ModelId) || !searchVM.TypeId.HasValue) &&
             (z.NameAr.Contains(searchVM.SearchKey) || z.NameEn.Contains(searchVM.SearchKey) ||
             string.IsNullOrEmpty(searchVM.SearchKey))).ToList();
            return View(result);
        }
        public List<SubCarType> GetSubTypeCar(int id)
        {
            var list = _Context.SubCarType.Where(x => x.CarTypeId == id && x.CategoryType == CategoryType.Firsr).ToList();
            return list;
        }
        public List<SubCarType> GetModelCar(int id)
        {
            var list = _Context.SubCarType.Where(x => x.CarTypeId == id && x.CategoryType == CategoryType.Second).ToList();
            return list;
        }
        public float GetPrice(int id)
        {
            var list = _Context.Service.Find(id);
            return list.PriceBeforeDiscount;
        }
    }
}
