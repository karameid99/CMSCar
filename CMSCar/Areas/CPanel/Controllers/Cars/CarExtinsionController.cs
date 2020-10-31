using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSCar.Areas.CPanel.Controllers.Cars
{
    public class CarExtinsionController : BaseController
    {
        private IWebHostEnvironment _environment;
        public CarExtinsionController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
            _environment = environment;
        }

        public JsonResult  ColorAjaxData([FromBody] dynamic data , int id)
        {
            DataTableHelper d = new DataTableHelper(data);
            var query = _Context.ColorCar.Where(x => x.CarId == id).ToList();
            int totalCount = query.Count();
            var items = query.Select(x => new
            {
                x.Id,
                x.NameAr,
                x.NameEn,
                createdAt = x.CreatedAt.ToString("MM/dd/yyyy"),
            }).Skip(d.Start).Take(d.Length).OrderByDescending(x => x.createdAt).ToList();
            var result = new {draw = d.Draw,recordsTotal = totalCount,recordsFiltered = totalCount, data = items};
            return Json(result);
        }

        public JsonResult SpecificationAjaxData([FromBody] dynamic data, int id)
        {
            DataTableHelper d = new DataTableHelper(data);
            var query = _Context.SpecificationCar.Where(x => x.CarId == id).ToList();
            int totalCount = query.Count();
            var items = query.Select(x => new
            {
                x.Id,
                x.NameAr,
                x.NameEn,
                createdAt = x.CreatedAt.ToString("MM/dd/yyyy"),
            }).Skip(d.Start).Take(d.Length).OrderByDescending(x => x.createdAt).ToList();
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = items };
            return Json(result);
        }
        public JsonResult FeatureAjaxData([FromBody] dynamic data, int id)
        {
            DataTableHelper d = new DataTableHelper(data);
            var query = _Context.FeatureCar.Where(x => x.CarId == id).ToList();
            int totalCount = query.Count();
            var items = query.Select(x => new
            {
                x.Id,
                x.NameAr,
                x.NameEn,
                createdAt = x.CreatedAt.ToString("MM/dd/yyyy"),
            }).Skip(d.Start).Take(d.Length).OrderByDescending(x => x.createdAt).ToList();
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = items };
            return Json(result);
        }

        public IActionResult AddColor(int id)
        {
            ViewBag.id = id;
            return View();       
        }
        [HttpPost]
        public async Task<IActionResult> AddColor(ColorCarDTO colorDto, List<IFormFile> Images)
        {
            if (ModelState.IsValid)
            {
                var colorCar = _Mapper.Map<ColorCar>(colorDto);
                _Context.Add(colorCar);
                _Context.SaveChanges();
                if (Images.Any())
                {
                    foreach (var item in Images)
                    {
                        ColorImage color = new ColorImage();
                        color.ImagePath = await ImageHelper.SaveImage(item, _environment, "Images/Car");
                        color.ColorCarId = colorCar.Id;
                        _Context.ColorImage.Add(color);
                    }
                    _Context.SaveChanges();

                }
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }



        public IActionResult EditColor(int id)
        {
            var color = _Context.ColorCar.Find(id);

            return View(_Mapper.Map<ColorCarUpdateDTO>(color));
        }
        [HttpPost]
        public async Task<IActionResult> EditColor(ColorCarUpdateDTO colorCardto, List<IFormFile> Images)
        {
            if (ModelState.IsValid)
            {
               var colorCar = _Mapper.Map<ColorCar>(colorCardto);
                var org = _Context.ColorCar.AsNoTracking().SingleOrDefault(x => x.Id == colorCar.Id);
                colorCar.CarId = org.CarId;
                _Context.ColorCar.Update(colorCar);
                _Context.SaveChanges();
                if (Images.Any())
                {
                    foreach (var item in Images)
                    {
                        ColorImage color = new ColorImage();
                        color.ImagePath = await ImageHelper.SaveImage(item, _environment, "Images/Car");
                        color.ColorCarId = colorCar.Id;
                        _Context.ColorImage.Add(color);
                    }
                    _Context.SaveChanges();
                }
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }
        public ActionResult DeleteColor(int? Id)
        {
            if (Id == null) return NotFound();
            var colorCar = _Context.ColorCar.Find(Id);
            if (colorCar == null) return NotFound();
            _Context.ColorCar.Remove(colorCar);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

        public IActionResult AddFeature(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(FeteureCreateDTO featureCarDto)
        {
            if (ModelState.IsValid)
            {
                var featureCar = _Mapper.Map<FeteureCreateDTO, FeatureCar>(featureCarDto);
                _Context.FeatureCar.Add(featureCar);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");

            }

            return View();
        }
        public IActionResult EditFeature(int id)
        {
            var Feature = _Context.FeatureCar.Find(id);

            return View(_Mapper.Map<FeteureUpdateDTO>(Feature));
        }
        [HttpPost]
        public IActionResult EditFeature(FeteureUpdateDTO featureCarDto)
        {
            if (ModelState.IsValid)
            {
                var featureCar = _Mapper.Map<FeteureUpdateDTO, FeatureCar>(featureCarDto);
                var org = _Context.FeatureCar.AsNoTracking().SingleOrDefault(x => x.Id == featureCar.Id);
                featureCar.CarId = org.CarId;
                featureCar.CreatedAt = org.CreatedAt;
                _Context.FeatureCar.Update(featureCar);
                _Context.SaveChanges();
                return Content(ResultMessage.StatusUpdateResult(), "application/json");

            }

            return View();
        }

        public ActionResult DeleteFeature(int? Id)
        {
            if (Id == null) return NotFound();
            var FeatureCar = _Context.FeatureCar.Find(Id);
            if (FeatureCar == null) return NotFound();
            _Context.FeatureCar.Remove(FeatureCar);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }



        public IActionResult AddSpecification(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddSpecification(SpecificationCreateDTO specificationCarDto)
        {
            if (ModelState.IsValid)
            {
                var specificationCar = _Mapper.Map<SpecificationCreateDTO, SpecificationCar>(specificationCarDto);
                _Context.SpecificationCar.Add(specificationCar);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");

            }

            return View();
        }
        public IActionResult EditSpecification(int id)
        {
            var Specification = _Context.SpecificationCar.Find(id);

            return View(_Mapper.Map<SpecificationUpdateDTO>(Specification));
        }
        [HttpPost]
        public IActionResult EditSpecification(SpecificationUpdateDTO specificationCarDto)
        {
            if (ModelState.IsValid)
            {
                var specificationCar = _Mapper.Map<SpecificationUpdateDTO, SpecificationCar>(specificationCarDto);
                var org = _Context.SpecificationCar.AsNoTracking().SingleOrDefault(x => x.Id == specificationCar.Id);
                specificationCar.CarId = org.CarId;
                specificationCar.CreatedAt = org.CreatedAt;
                _Context.SpecificationCar.Update(specificationCar);
                _Context.SaveChanges();
                return Content(ResultMessage.StatusUpdateResult(), "application/json");

            }

            return View();
        }

        public ActionResult DeleteSpecification(int? Id)
        {
            if (Id == null) return NotFound();
            var specificationCar = _Context.SpecificationCar.Find(Id);
            if (specificationCar == null) return NotFound();
            _Context.SpecificationCar.Remove(specificationCar);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }


    }
}
