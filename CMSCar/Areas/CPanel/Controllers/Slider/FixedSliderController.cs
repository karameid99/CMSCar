using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.Sliders;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Slider
{
    public class FixedSliderController : BaseController
    {
        private IWebHostEnvironment _environment;
        public FixedSliderController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
            _environment = environment;
        }
        public JsonResult AjaxData([FromBody] dynamic data)
        {
            DataTableHelper d = new DataTableHelper(data);
            string jsonString = data.ToString();
            JObject ss = JObject.Parse(jsonString);
            var query = _Context.FixedSlider.Where(x =>
                (d.SearchKey == null
                || x.Layer1.Contains(d.SearchKey)
                || x.Layer2.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Select(x => new
            {
                x.Id,
                x.Layer1,
                x.Layer2,
                createAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                x.CreatedAt,
                x.IsActive
            }).Skip(d.Start).Take(d.Length).ToList();
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = items };
            return Json(result);
        }
        [HttpGet]
        public  ActionResult Activate(int? Id, bool Active)
        {
            if (Id == null) return NotFound();
            FixedSlider slider = _Context.FixedSlider.Find(Id);
            if (slider != null)
            {
                slider.IsActive = Active;
                _Context.SaveChanges();
                return Content(ResultMessage.StatusUpdateResult(), "application/json");
            }
            else
                return Content(ResultMessage.FailedResult(), "application/json");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var slider = _Context.FixedSlider.Find(id);
            if (slider == null)
            {
                return NotFound();
            }
            var dto = _Mapper.Map<FixedSliderDto>(slider);

            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FixedSliderDto model)
        {
            var orgSlider = _Context.FixedSlider.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
            if (model.IMGLayer3 != null)
            {
                orgSlider.Layer3 = await ImageHelper.SaveImage(model.IMGLayer3, _environment, "Images/Slider");
            }
            if (model.IMGLayer4 != null)
            {
                orgSlider.Layer4 = await ImageHelper.SaveImage(model.IMGLayer4, _environment, "Images/Slider");
            }
            if (model.IMGLayer5 != null)
            {
                orgSlider.Layer5 = await ImageHelper.SaveImage(model.IMGLayer5, _environment, "Images/Slider");
            }
            if (model.IMGLayer6 != null)
            {
                orgSlider.Layer6 = await ImageHelper.SaveImage(model.IMGLayer6, _environment, "Images/Slider");
            }
            if (model.IMGLayer7 != null)
            {
                orgSlider.Layer7 = await ImageHelper.SaveImage(model.IMGLayer7, _environment, "Images/Slider");
            }
            if (model.IMGLayer8 != null)
            {
                orgSlider.Layer8 = await ImageHelper.SaveImage(model.IMGLayer8, _environment, "Images/Slider");
            }
            if (model.IMGLayer9 != null)
            {
                orgSlider.Layer9 = await ImageHelper.SaveImage(model.IMGLayer9, _environment, "Images/Slider");
            }
            if (model.IMGLayer10 != null)
            {
                orgSlider.Layer10 = await ImageHelper.SaveImage(model.IMGLayer10, _environment, "Images/Slider");
            }
            if (model.IMGLayer11 != null)
            {
                orgSlider.Layer11 = await ImageHelper.SaveImage(model.IMGLayer11, _environment, "Images/Slider");
            }
            if (model.IMGLayer12 != null)
            {
                orgSlider.Layer12 = await ImageHelper.SaveImage(model.IMGLayer12, _environment, "Images/Slider");
            }
            if (model.IMGLayer13 != null)
            {
                orgSlider.Layer13 = await ImageHelper.SaveImage(model.IMGLayer13, _environment, "Images/Slider");
            }
            if (model.IMGLayer14 != null)
            {
                orgSlider.Layer14 = await ImageHelper.SaveImage(model.IMGLayer14, _environment, "Images/Slider");
            }
            if (model.IMGLayer15 != null)
            {
                orgSlider.Layer15 = await ImageHelper.SaveImage(model.IMGLayer15, _environment, "Images/Slider");
            }
            if (model.IMGLayer16 != null)
            {
                orgSlider.Layer16 = await ImageHelper.SaveImage(model.IMGLayer16, _environment, "Images/Slider");
            }
            if (model.IMGLayer17 != null)
            {
                orgSlider.Layer17 = await ImageHelper.SaveImage(model.IMGLayer17, _environment, "Images/Slider");
            }
            if (model.IMGLayer18 != null)
            {
                orgSlider.Layer18 = await ImageHelper.SaveImage(model.IMGLayer18, _environment, "Images/Slider");
            }
            if (model.IMGLayer19 != null)
            {
                orgSlider.Layer19 = await ImageHelper.SaveImage(model.IMGLayer19, _environment, "Images/Slider");
            }
            orgSlider.Layer1 = model.Layer1;
            orgSlider.Layer2 = model.Layer2;
            orgSlider.Layer20 = model.Layer20;
            orgSlider.Layer19 = model.Layer19;
            _Context.FixedSlider.Update(orgSlider);
            _Context.SaveChanges();
            return RedirectToAction("Edit" ,model.Id);
        }

    }
}
