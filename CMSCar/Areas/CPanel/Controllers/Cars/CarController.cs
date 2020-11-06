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
using Microsoft.EntityFrameworkCore;
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
                var sct = new CarCategory
                {
                    CarId = car.Id,
                    SubCarTypeId = model.SubCarTypeId
                };
                var sct2 = new CarCategory
                {
                    CarId = car.Id,
                    SubCarTypeId = model.ModelCarTypeId
                };
                _Context.CarCategory.Add(sct);
                _Context.CarCategory.Add(sct2);
                _Context.SaveChanges();

                if (model.InsidImages.Count() != 0)
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
                return RedirectToAction("Color", new { id = car.Id });
            }
            ViewData["TypeCar"] = new SelectList(_Context.CarType, "Id", "NameAr");
            return View();
        }
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null) return NotFound();
        //    var car = _Context.Car.SingleOrDefault(x => x.Id == id);
        //    if (car == null) return NotFound();
        //    var carDto = _Mapper.Map<CarDTO>(car);
        //    carDto.CarTypeId = _Context.CarType.SingleOrDefault(x => x.Id == car.SubCarType.CarTypeId).Id;
        //    ViewData["TypeCar"] = new SelectList(_Context.CarType, "Id", "NameAr");
        //    return View(carDto);
        //}
        [HttpPost]
        public async Task<IActionResult> Edit(CarDTO model)
        {
            if (ModelState.IsValid)
            {
                var car = _Mapper.Map<Car>(model);
                var org = _Context.Car.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                if (model.Main != null)
                {
                    car.MainImage = await ImageHelper.SaveImage(model.Main, _environment, "Images/Car");
                }
                else
                {
                    car.MainImage = org.MainImage;
                }
                if (model.Show != null)
                {
                    car.ShowImage = await ImageHelper.SaveImage(model.Show, _environment, "Images/Car");
                }
                else
                {
                    car.ShowImage = org.ShowImage;
                }
                _Context.Car.Update(car);
                _Context.SaveChanges();
                if (model.InsidImages != null)
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
                return RedirectToAction("Color", new { id = car.Id });
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
            var list = _Context.SubCarType.Where(x => x.CarTypeId == id && x.CategoryType == Models.CategoryType.Firsr).ToList();
            return list;
        }

        public List<SubCarType> GetModel(int id)
        {
            var list = _Context.SubCarType.Where(x => x.CarTypeId == id && x.CategoryType == Models.CategoryType.Second).ToList();
            return list;
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var car = _Context.Car.Find(id);
            if (car == null) return NotFound();
            _Context.Car.Remove(car);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}
