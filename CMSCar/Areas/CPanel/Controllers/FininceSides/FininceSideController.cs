using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.Home;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.FininceSides
{
    public class FininceSideController : BaseController
    {
        private IWebHostEnvironment _environment;
        public FininceSideController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.FininceSide.Where(x =>
                (d.SearchKey == null
                || x.NameAr.Contains(d.SearchKey)
                || x.NameEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<FininceSideVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FininceSideDTO model)
        {
            if (ModelState.IsValid)
            {
                var fininceSide = _Mapper.Map<FininceSide>(model);
                fininceSide.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/FininceSide");
                _Context.FininceSide.Add(fininceSide);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var fininceSide = _Context.FininceSide.Find(id);
            if (fininceSide == null) return NotFound();

            return View(_Mapper.Map<FininceSideDTO>(fininceSide));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FininceSideDTO model)
        {
            if (ModelState.IsValid)
            {
                var fininceSide = _Mapper.Map<FininceSide>(model);
                var orgFininceSide = _Context.FininceSide.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                if (model.Image != null)
                { fininceSide.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/FininceSide"); }
                else { fininceSide.ImagePath = orgFininceSide.ImagePath; }
                fininceSide.CreatedAt = orgFininceSide.CreatedAt;
                _Context.FininceSide.Update(fininceSide);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }


        public ActionResult Delete(int? Id)
        {
            if (Id == null) return NotFound();
            var fininceSide = _Context.FininceSide.Find(Id);
            if (fininceSide == null) return NotFound();
            _Context.FininceSide.Remove(fininceSide);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

    }
}
