using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Cars
{
    public class CarController : BaseController
    {
        private IWebHostEnvironment _environment;
        public CarController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AjaxData([FromBody] dynamic data)
        {
            DataTableHelper d = new DataTableHelper(data);
            string jsonString = data.ToString();
            JObject ss = JObject.Parse(jsonString);
            var query = _Context.Car.Where(x =>
                (d.SearchKey == null
                || x.NameAr.Contains(d.SearchKey)
                || x.NameEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<CarVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }

        public IActionResult Create()
        {
            ViewData["TypeCar"] = new SelectList(_Context.CarType, "Id", "NameAr");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarDTO model)
        {
            if (ModelState.IsValid)
            {
                var car = _Mapper.Map<Car>(model);
                car.MainImage = await ImageHelper.SaveImage(model.Main, _environment, "Images/Car");
                car.ShowImage = await ImageHelper.SaveImage(model.Show, _environment, "Images/Car");
                _Context.Car.Add(car);
                _Context.SaveChanges();
                if (model.InsidImages.Any())
                {
                    foreach (var item in model.InsidImages)
                    {
                        CarImage carImage = new CarImage();
                        carImage.CarId = car.Id;
                        carImage.ImagePath = await ImageHelper.SaveImage(item, _environment, "Images/Car");
                        _Context.CarImage.Add(carImage);
                    }
                    _Context.SaveChanges();

                }
                return RedirectToAction("Color",new {id = car.Id });
            }
            ViewData["Cars"] = new SelectList(_Context.Car, "Id", "NameAr");
            return View();
        }
        public IActionResult Color(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public List<SubCarType> GetSubTypeCar(int id)
        {
            var list = _Context.SubCarType.Where(x => x.CarTypeId == id).ToList();
            return list;
        }
    }
}
