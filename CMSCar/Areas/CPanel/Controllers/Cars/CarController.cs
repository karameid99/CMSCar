using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using Microsoft.EntityFrameworkCore.Internal;
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
            ViewBag.ci = Guid.NewGuid();
            var carDto = new CarDTO
            {
                featureCars = _Context.FeatureCar.Include(x => x.subFeatureCars).Where(x => !x.CarId.HasValue).ToList(),
                specificationCars = _Context.SpecificationCar.Include(x => x.subSpecificationCars).Where(x => !x.CarId.HasValue).ToList(),
            };
            ViewData["TypeCar"] = new SelectList(_Context.CarType, "Id", "NameAr");
            return View(carDto);
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
                var colors = _Context.ColorCar.Where(x => x.CarIdentfire == car.CarIdentfire).ToList();
                foreach (var item in colors)
                {
                    item.CarId = car.Id;
                    _Context.SaveChanges();
                }
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
                _Context.SaveChanges();
                if (model.feature != null)
                {
                    var subType = _Context.FeatureCar.Include(x => x.subFeatureCars).Where(x => model.feature.Any(m => m == x.Id)).ToList();
                    var subFeatureType = _Context.SubFeatureCar.Where(x => model.subFeatureCars.Any(m => m == x.Id)).ToList();
                    foreach (var item in subType)
                    {
                        var fc = new FeatureCar
                        {
                            CarId = car.Id,
                            NameAr = item.NameAr,
                            NameEn = item.NameEn,
                            CarIdentfire = item.CarIdentfire
                        };
                        _Context.FeatureCar.Add(fc);
                        _Context.SaveChanges();
                        for (var item1 = 0; item1 < subFeatureType.Count; item1++)
                        {
                            if (item.Id == subFeatureType[item1].FeatureCarId)
                            {
                                var sfc = new SubFeatureCar
                                {
                                    FeatureCarId = fc.Id,
                                    NameAr = subFeatureType[item1].NameAr,
                                    NameEn = subFeatureType[item1].NameEn,
                                    AnswerAr = model.arValues[item1],
                                    AnswerEn = model.enValues[item1]
                                };
                                _Context.SubFeatureCar.Add(sfc);
                            }
                        }
                        _Context.SaveChanges();
                    }
                }
                if (model.SepCars != null)
                {
                    var sepCar = _Context.SpecificationCar.Include(x => x.subSpecificationCars).Where(x => model.SepCars.Any(m => m == x.Id)).ToList();
                    if (model.subSepCars != null)
                    {
                        var subSpType = _Context.SubSpecificationCar.Where(x => model.subSepCars.Any(m => m == x.Id)).ToList();
                        if (sepCar != null)
                        {
                            foreach (var item in sepCar)
                            {
                                var sc = new SpecificationCar
                                {
                                    CarId = car.Id,
                                    NameAr = item.NameAr,
                                    NameEn = item.NameEn,
                                    CarIdentfire = item.CarIdentfire
                                };
                                _Context.SpecificationCar.Add(sc);
                                _Context.SaveChanges();
                                if (subSpType != null)
                                {
                                    for (var item1 = 0; item1 < subSpType.Count; item1++)
                                    {
                                        if (item.Id == subSpType[item1].SpecificationCarId)
                                        {
                                            var sfc = new SubSpecificationCar
                                            {
                                                SpecificationCarId = sc.Id,
                                                NameAr = subSpType[item1].NameAr,
                                                NameEn = subSpType[item1].NameEn,
                                                AnswerAr = model.SepAr[item1],
                                                AnswerEn = model.SepEn[item1]
                                            };
                                            _Context.SubSpecificationCar.Add(sfc);
                                        }

                                    }
                                }
                                _Context.SaveChanges();

                            }
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["TypeCar"] = new SelectList(_Context.CarType, "Id", "NameAr");
            return RedirectToAction("Create");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var car = _Context.Car.SingleOrDefault(x => x.Id == id);
            if (car == null) return NotFound();
            ViewBag.ci = car.CarIdentfire;

            var carDto = _Mapper.Map<CarDTO>(car);

            var type = _Context.CarCategory.Include(x => x.SubCarType).ThenInclude(s => s.CarType).SingleOrDefault(x => x.CarId == car.Id && x.SubCarType.CategoryType == Areas.CPanel.Models.CategoryType.Firsr);
            carDto.CarTypeId = type.SubCarType.CarTypeId;
            carDto.ModelCarTypeId = _Context.CarCategory.Include(x => x.SubCarType).SingleOrDefault(x => x.CarId == id && x.SubCarType.CategoryType == Models.CategoryType.Second).SubCarType.Id;
            carDto.SubCarTypeId = _Context.CarCategory.Include(x => x.SubCarType).SingleOrDefault(x => x.CarId == id && x.SubCarType.CategoryType == Models.CategoryType.Firsr).SubCarType.Id;

            var featureCars = await _Context.FeatureCar.Include(x => x.subFeatureCars).Where(x => x.CarId == id).ToListAsync();
            var ds = await _Context.FeatureCar.Include(x => x.subFeatureCars).Where
            (x => !x.CarId.HasValue).ToListAsync();
            for (int i = 0; i < featureCars.Count; i++)
            {
                for (int j = 0; j < ds.Count; j++)
                {
                    if (featureCars[i].CarIdentfire == ds[j].CarIdentfire)
                    {
                        foreach (var item in featureCars[i].subFeatureCars)
                        {
                            for (int y = 0; y < ds[j].subFeatureCars.Count; y++)
                            {
                                ds[j].isTake = true;
                                if (ds[j].subFeatureCars[y].NameAr == item.NameAr)
                                {
                                    ds[j].subFeatureCars[y].AnswerAr = item.AnswerAr;
                                    ds[j].subFeatureCars[y].AnswerEn = item.AnswerEn;
                                }
                            }
                        }

                    }
                }

            }
            carDto.featureCars = ds;

            var specificationCars = _Context.SpecificationCar.Include(x => x.subSpecificationCars).Where(x => x.CarId == id).ToList();
            var dss = await _Context.SpecificationCar.Include(x => x.subSpecificationCars).Where
            (x => !x.CarId.HasValue).ToListAsync();

            for (int i = 0; i < specificationCars.Count; i++)
            {
                for (int j = 0; j < dss.Count; j++)
                {
                    if (specificationCars[i].CarIdentfire == dss[j].CarIdentfire)
                    {
                        foreach (var item in specificationCars[i].subSpecificationCars)
                        {
                            for (int y = 0; y < dss[j].subSpecificationCars.Count; y++)
                            {
                                dss[j].isTake = true;
                                if (dss[j].subSpecificationCars[y].NameAr == item.NameAr)
                                {
                                    dss[j].subSpecificationCars[y].AnswerAr = item.AnswerAr;
                                    dss[j].subSpecificationCars[y].AnswerEn = item.AnswerEn;
                                }
                            }
                        }

                    }
                }

            }
            carDto.specificationCars = dss;
            return View(carDto);
        }
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
               await _Context.SaveChangesAsync();
                DeleteAllSubFeature(org.Id);
                DeleteAllSubsep(org.Id);
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
                if (model.feature != null)
                {
                    var subType = await _Context.FeatureCar.Include(x => x.subFeatureCars).Where(x => model.feature.Any(m => m == x.Id)).ToListAsync();
                    var subFeatureType = await _Context.SubFeatureCar.Where(x => model.subFeatureCars.Any(m => m == x.Id)).ToListAsync();
                    foreach (var item in subType)
                    {
                        var fc = new FeatureCar
                        {
                            CarId = car.Id,
                            NameAr = item.NameAr,
                            NameEn = item.NameEn,
                            CarIdentfire = item.CarIdentfire
                        };
                        _Context.FeatureCar.Add(fc);
                        _Context.SaveChanges();
                        for (var item1 = 0; item1 < subFeatureType.Count; item1++)
                        {
                            if (item.Id == subFeatureType[item1].FeatureCarId)
                            {
                                var sfc = new SubFeatureCar
                                {
                                    FeatureCarId = fc.Id,
                                    NameAr = subFeatureType[item1].NameAr,
                                    NameEn = subFeatureType[item1].NameEn,
                                    AnswerAr = model.arValues[item1],
                                    AnswerEn = model.enValues[item1]
                                };
                                _Context.SubFeatureCar.Add(sfc);
                            }
                        }
                        await _Context.SaveChangesAsync();
                    }
                }
                if (model.SepCars != null)
                {
                    var sepCar = await _Context.SpecificationCar.Include(x => x.subSpecificationCars).Where(x => model.SepCars.Any(m => m == x.Id)).ToListAsync();
                    if (model.subSepCars != null)
                    {
                        var subSpType = await _Context.SubSpecificationCar.Where(x => model.subSepCars.Any(m => m == x.Id)).ToListAsync();
                        if (sepCar != null)
                        {
                            foreach (var item in sepCar)
                            {
                                var sc = new SpecificationCar
                                {
                                    CarId = car.Id,
                                    NameAr = item.NameAr,
                                    NameEn = item.NameEn,
                                    CarIdentfire = item.CarIdentfire
                                };
                                _Context.SpecificationCar.Add(sc);
                                await _Context.SaveChangesAsync();
                                if (subSpType != null)
                                {
                                    for (var item1 = 0; item1 < subSpType.Count; item1++)
                                    {
                                        if (item.Id == subSpType[item1].SpecificationCarId)
                                        {
                                            var sfc = new SubSpecificationCar
                                            {
                                                SpecificationCarId = sc.Id,
                                                NameAr = subSpType[item1].NameAr,
                                                NameEn = subSpType[item1].NameEn,
                                                AnswerAr = model.SepAr[item1],
                                                AnswerEn = model.SepEn[item1]
                                            };
                                            _Context.SubSpecificationCar.Add(sfc);
                                        }
                                    }
                                }
                                await _Context.SaveChangesAsync();
                            }
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Cars"] = new SelectList(_Context.Car, "Id", "NameAr");
            return View();
        }
        public IActionResult Color(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> GetTypeCar()
        {
            var list = await _Context.CarType.ToListAsync();
            return Json(list);
        }
        public async Task<IActionResult> GetSubTypeCar(int id)
        {
            var list = await _Context.SubCarType.Where(x => x.CarTypeId == id && x.CategoryType == Models.CategoryType.Firsr).ToListAsync();
            return Json(list);
        }

        public async Task<IActionResult> GetModel(int id)
        {
            var list = await _Context.SubCarType.Where(x => x.CarTypeId == id && x.CategoryType == Models.CategoryType.Second).ToListAsync();
            return Json(list);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var car = _Context.Car.Find(id);
            if (car == null) return NotFound();
            var colors = _Context.ColorCar.Where(x => x.CarId == car.Id).ToList();
            var Featsurs = _Context.FeatureCar.Where(x => x.CarId == car.Id).ToList();
            var Supsfication = _Context.SpecificationCar.Where(x => x.CarId == car.Id).ToList();
            foreach (var item in colors)
            {
                _Context.ColorCar.Remove(item);

            }
            foreach (var item in Featsurs)
            {
                _Context.FeatureCar.Remove(item);

            }
            foreach (var item in Supsfication)
            {
                _Context.SpecificationCar.Remove(item);

            }
            _Context.Car.Remove(car);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
        public async void DeleteAllSubFeature(int carId)
        {
            var Features = await _Context.FeatureCar.Where(x => x.CarId == carId).ToListAsync();
            _Context.RemoveRange(Features);
            await _Context.SaveChangesAsync();
        }
        public async void DeleteAllSubsep(int carId)
        {
            var Features = await _Context.SpecificationCar.Where(x => x.CarId == carId).ToListAsync();

            _Context.RemoveRange(Features);
            await _Context.SaveChangesAsync();
        }
    }
}
