using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs.SubFS;
using CMSCar.Areas.CPanel.Models.Cars;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSCar.Areas.CPanel.Controllers.Cars
{
    public class SubFCController : BaseController
    {
        public SubFCController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }

        public IActionResult IndexSF(int id)
        {
            ViewBag.id = id;
            var items = _Context.SubFeatureCar.Where(x => x.FeatureCarId == id).ToList();
            return View(items);
        }
       
        public IActionResult IndexSC(int id)
        {
            ViewBag.id = id;
            var items = _Context.SubSpecificationCar.Where(x => x.SpecificationCarId == id).ToList();
            return View(items);
        }
        public IActionResult CreateSF(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateSF(SubFeatureCarDTO model)
        {
            if (ModelState.IsValid)
            {
                var subCarType = _Mapper.Map<SubFeatureCar>(model);
                _Context.SubFeatureCar.Add(subCarType);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }
        public IActionResult CreateSC(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]

        public IActionResult CreateSC(SubSpecificationCarDTO model)
        {
            if (ModelState.IsValid)
            {
                var subCarType = _Mapper.Map<SubSpecificationCar>(model);
                _Context.SubSpecificationCar.Add(subCarType);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult EditSF(int id)
        {
            var item = _Context.SubFeatureCar.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(_Mapper.Map<SubFeatureCar, SubFeatureCarUpdateDTO>(item));
        }
        public IActionResult EditSC(int id)
        {
            var item = _Context.SubSpecificationCar.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(_Mapper.Map<SubSpecificationCar, SubSpecificationCarUpdateDTO>(item));
        }
        [HttpPost]
        public IActionResult EditSF(SubFeatureCarUpdateDTO subFeatureCarUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                var featureCar = _Mapper.Map<SubFeatureCarUpdateDTO, SubFeatureCar>(subFeatureCarUpdateDTO);
                var orgFC = _Context.SubFeatureCar.AsNoTracking().SingleOrDefault(x => x.Id == subFeatureCarUpdateDTO.Id);
                featureCar.FeatureCarId = orgFC.FeatureCarId;
                _Context.SubFeatureCar.Update(featureCar);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");

            }
            return View();
        }
        [HttpPost]

        public IActionResult EditSC(SubSpecificationCarUpdateDTO subSpecificationCarUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                var featureCar = _Mapper.Map<SubSpecificationCarUpdateDTO, SubSpecificationCar>(subSpecificationCarUpdateDTO);
                var orgFC = _Context.SubSpecificationCar.AsNoTracking().SingleOrDefault(x => x.Id == subSpecificationCarUpdateDTO.Id);
                featureCar.SpecificationCarId = orgFC.SpecificationCarId;
                _Context.SubSpecificationCar.Update(featureCar);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");

            }
            return View();
        }

        public ActionResult DeleteSC(int? Id)
        {
            if (Id == null) return NotFound();
            var specificationCar = _Context.SubSpecificationCar.Find(Id);
            if (specificationCar == null) return NotFound();
            _Context.SubSpecificationCar.Remove(specificationCar);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

        public ActionResult DeleteSF(int? Id)
        {
            if (Id == null) return NotFound();
            var specificationCar = _Context.SubFeatureCar.Find(Id);
            if (specificationCar == null) return NotFound();
            _Context.SubFeatureCar.Remove(specificationCar);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}