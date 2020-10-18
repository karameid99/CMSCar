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
    public class BranchController : BaseController
    {
        public BranchController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }
        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();
            var city = _Context.City.Find(id);
            if (city == null) return NotFound();
            return View(city);
        }
        public JsonResult AjaxData([FromBody] dynamic data, int id)
        {
            DataTableHelper d = new DataTableHelper(data);
            string jsonString = data.ToString();
            JObject ss = JObject.Parse(jsonString);
            var query = _Context.Branch.Where(x => x.CityId == id &&
                (d.SearchKey == null
                || x.NameAr.Contains(d.SearchKey)
                || x.NameEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<BranchVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(BranchDTO model)
        {
            if (ModelState.IsValid)
            {
                var branch = _Mapper.Map<Branch>(model);
                _Context.Branch.Add(branch);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var branch = _Context.Branch.Find(id);
            if (branch == null) return NotFound();

            return View(_Mapper.Map<BranchUpdateDTO>(branch));
        }
        [HttpPost]
        public IActionResult Edit(BranchUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var branch = _Mapper.Map<Branch>(model);
                var orgbranch = _Context.Branch.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                branch.CreatedAt = orgbranch.CreatedAt;
                _Context.Branch.Update(branch);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var branch = _Context.Branch.Find(id);
            if (branch == null) return NotFound();
            _Context.Branch.Remove(branch);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

    }
}
