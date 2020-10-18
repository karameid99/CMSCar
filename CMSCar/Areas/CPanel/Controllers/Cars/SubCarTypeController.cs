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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Cars
{
    public class SubCarTypeController : BaseController
    {
        public SubCarTypeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }
        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();
            var carType = _Context.CarType.Find(id);
            if (carType == null) return NotFound();
            return View(carType);
        }
        public JsonResult AjaxData([FromBody] dynamic data ,int id)
        {
            DataTableHelper d = new DataTableHelper(data);
            string jsonString = data.ToString();
            JObject ss = JObject.Parse(jsonString);
            var query = _Context.SubCarType.Where(x => x.CarTypeId == id &&
                (d.SearchKey == null
                || x.NameAr.Contains(d.SearchKey)
                || x.NameEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<SubCarTypeVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(SubCarTypeDTO model )
        {
            if (ModelState.IsValid)
            {
                var subCarType = _Mapper.Map<SubCarType>(model);
                _Context.SubCarType.Add(subCarType);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var subCarType = _Context.SubCarType.Find(id);
            if (subCarType == null) return NotFound();

            return View(_Mapper.Map<SubCarTypeUpdateDTO>(subCarType));
        }
        [HttpPost]
        public IActionResult Edit(SubCarTypeUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var subCarType = _Mapper.Map<SubCarType>(model);
                //var orgSubCarType = _Context.SubCarType.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                //subCarType.CreatedAt = orgSubCarType.CreatedAt;
                _Context.SubCarType.Update(subCarType);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var subCarType = _Context.SubCarType.Find(id);
            if (subCarType == null) return NotFound();
            _Context.SubCarType.Remove(subCarType);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

    }
}
