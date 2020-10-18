using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.Contact;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Contact
{
    public class CityController : BaseController
    {
        public CityController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
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
            var query = _Context.City.Where(x =>
                (d.SearchKey == null
                || x.CityAr.Contains(d.SearchKey)
                || x.CityEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<CityVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CityDTO model)
        {
            if (ModelState.IsValid)
            {
                var city = _Mapper.Map<City>(model);
                _Context.City.Add(city);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var city = _Context.City.Find(id);
            if (city == null) return NotFound();

            return View(_Mapper.Map<CityDTO>(city));
        }
        [HttpPost]
        public IActionResult Edit(CityDTO model)
        {
            if (ModelState.IsValid)
            {
                var city = _Mapper.Map<City>(model);
                var orgCity = _Context.City.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                city.CreatedAt = orgCity.CreatedAt;
                _Context.City.Update(city);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var city = _Context.City.Find(id);
            if (city == null) return NotFound();
            _Context.City.Remove(city);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

    }
}
