using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.FundingBodies;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.WhyUs
{
    public class WhyUsController : BaseController
    {
        private IWebHostEnvironment _environment;
        public WhyUsController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.WhyUs.Where(x =>
                (d.SearchKey == null
                || x.NameAr.Contains(d.SearchKey)
                || x.NameEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<WhyUsVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WhyUsDTO model)
        {
            if (ModelState.IsValid)
            {
                var whyUs = _Mapper.Map<CMSCar.Areas.CPanel.Models.FundingBodies.WhyUs>(model);
                whyUs.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/WhyUs");
                _Context.WhyUs.Add(whyUs);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var whyUs = _Context.WhyUs.Find(id);
            if (whyUs == null) return NotFound();

            return View(_Mapper.Map<WhyUsDTO>(whyUs));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(WhyUsDTO model)
        {
            if (ModelState.IsValid)
            {
                var whyUs = _Mapper.Map<CMSCar.Areas.CPanel.Models.FundingBodies.WhyUs>(model);
                var orgWhyUs = _Context.WhyUs.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                if (model.Image != null)
                { whyUs.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/WhyUs"); }
                else { whyUs.ImagePath = orgWhyUs.ImagePath; }
                whyUs.CreatedAt = orgWhyUs.CreatedAt;
                _Context.WhyUs.Update(whyUs);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }


        public ActionResult Delete(int? Id)
        {
            if (Id == null) return NotFound();
            var whyUs = _Context.WhyUs.Find(Id);
            if (whyUs == null) return NotFound();
            _Context.WhyUs.Remove(whyUs);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
        public ActionResult OrderWhyUs(int Id, int value)
        {
            var model = _Context.WhyUs.Find(Id);
            model.OrderBy = value;
            _Context.SaveChanges();
            return Content(ResultMessage.EditSuccessResult(), "application/json");

        }
    }
}
