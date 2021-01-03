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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Cars
{
    public class CarTypeController : BaseController
    {
        private IWebHostEnvironment _environment;
        public CarTypeController( IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.CarType.Where(x =>
                (d.SearchKey == null
                || x.NameAr.Contains(d.SearchKey)
                || x.NameEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.OrderByDescending(x=> x.CreatedAt).Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<CarTypeVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                var carType = _Mapper.Map<CarType>(model);
                carType.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/CarType");
                _Context.CarType.Add(carType);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var carType = _Context.CarType.Find(id);
            if (carType == null) return NotFound();

            return View(_Mapper.Map<CarTypeDTO>(carType));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                var carType = _Mapper.Map<CarType>(model);
                var orgCarType = _Context.CarType.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                if (model.Image != null)
                {carType.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/CarType");}
                else{carType.ImagePath = orgCarType.ImagePath;}
                carType.CreatedAt = orgCarType.CreatedAt;
                _Context.CarType.Update(carType);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }


        public ActionResult Delete(int? Id)
        {
            if (Id == null) return NotFound();
            var carType = _Context.CarType.Find(Id);
            if (carType == null) return NotFound();
            _Context.CarType.Remove(carType);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

    }
}
