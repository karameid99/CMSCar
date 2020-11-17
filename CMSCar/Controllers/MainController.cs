using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models.Mails;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CMSCar.Controllers
{
    public class MainController : BaseController
    {
        private readonly ILogger<MainController> _logger;
        private readonly IMapper _Mapper;

        public MainController(ApplicationDbContext context, ILogger<MainController> logger, IMapper mapper) : base(context)
        {
            _logger = logger;
            _Mapper = mapper;
        }
        public IActionResult Offers()
        {
            return View();
        }

        public IActionResult Vision()
        {
            var model = _Context.WhoWeAre.FirstOrDefault();
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = _Context.WhoWeAre.FirstOrDefault();
            return View(model);
        }

        public IActionResult Conditions()
        {
            var model = _Context.WhoWeAre.FirstOrDefault();
            return View(model);
        }

        public IActionResult OfferDetalis(int? id)
        {
            if (id == null) return NotFound();
            var offer = _Context.Offer.Include(x => x.OfferCars).ThenInclude(m => m.Car).SingleOrDefault(x => x.Id == id);
            if (offer == null) return NotFound();
            return View(offer);
        }

        public IActionResult Discount(int? id)
        {
            Models.ViewModels.OfferVM vm = new Models.ViewModels.OfferVM();
            vm.CarTypes = _Context.CarType.ToList();
            vm.Cars = _Context.Car.Include(x => x.CarCategorys).ThenInclude(c => c.SubCarType).ThenInclude(x => x.CarType).Where(x => (x.CarCategorys.Any(x => x.SubCarType.CategoryType == Areas.CPanel.Models.CategoryType.Second))&&(x.CarCategorys.Any(x => x.SubCarType.CarTypeId == id) || id == null) && x.PriceAfterDiscount != 0).ToList();
            return View(vm);
        }
        public IActionResult Cars(int? id, int? subId)
        {
            if (id == null) return NotFound();
            var CarType = _Context.CarType.Find(id);
            if (CarType == null) return NotFound();
            ViewBag.Id = id;
            SubCarVM vm = new SubCarVM();
            vm.nameAr = CarType.NameAr;
            vm.nameEn = CarType.NameEn;
            vm.CarTypes = _Context.SubCarType.Where(x => x.CarTypeId == id && x.CategoryType == Areas.CPanel.Models.CategoryType.Firsr).ToList();
            vm.Cars = _Context.Car.Include(x => x.CarCategorys).ThenInclude(c => c.SubCarType).ThenInclude(x => x.CarType).Where(x => (x.CarCategorys.Any(x => x.SubCarType.CategoryType == Areas.CPanel.Models.CategoryType.Second)) && (x.CarCategorys.Any(x => x.SubCarType.CarTypeId == id) || id == null) && (x.CarCategorys.Any(x => x.SubCarTypeId == subId) || subId == null)).ToList();
            return View(vm);
        }
        public IActionResult Brands()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Email(Mail mail)
        {

            if (ModelState.IsValid)
            {
                _Context.Add(mail);
                await _Context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        public IActionResult Car(int id)
        {
            var car = _Context.Car.Include(x => x.ColorCars).ThenInclude(x => x.colorImages).Include(v => v.CarCategorys).ThenInclude(b => b.SubCarType).ThenInclude(c => c.CarType).Include(z => z.carImages).Include(x => x.SpecificationCars).ThenInclude(o => o.subSpecificationCars).Include(m => m.FeatureCars).ThenInclude(p => p.subFeatureCars).Where(c => c.Id == id).SingleOrDefault();
            var CarVM = _Mapper.Map<CarDetalesVM>(car);
            var subCar = _Context.CarCategory.Include(x => x.SubCarType).ThenInclude(s => s.CarType).SingleOrDefault(x => x.CarId == car.Id && x.SubCarType.CategoryType == Areas.CPanel.Models.CategoryType.Second);
            CarVM.SubCarTypeAr = subCar.SubCarType.NameAr;
            CarVM.SubCarTypeEn = subCar.SubCarType.NameEn;
            CarVM.SubCarTypeId = subCar.SubCarType.Id;
            CarVM.CarTypeAr = subCar.SubCarType.CarType.NameAr;
            CarVM.CarTypeEn = subCar.SubCarType.CarType.NameEn;
            CarVM.CarTypeId = subCar.SubCarType.CarType.Id;
            return View(CarVM);
        }
        public List<ColorImage> ColorsImage(int clrId)
        {
            var images = _Context.ColorImage.Where(x => x.ColorCarId == clrId).ToList();
            return images;
        }
        public string Colorar(int clrId, string lang)
        {
            if (lang == "ar-EG")
            {
                var name = _Context.ColorCar.Find(clrId).NameAr;
                return name;
            }
            else
            {
                var name = _Context.ColorCar.Find(clrId).NameEn;
                return name;
            }

        }
        public string Coloren(int clrId)
        {
            var name = _Context.ColorCar.Find(clrId).NameEn;
            return name;
        }
    }
}
