using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
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
    public class SliderController : BaseController
    {

        private IWebHostEnvironment _environment;
        public SliderController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.Slider.Where(x =>
                (d.SearchKey == null
                || x.TitleAr.Contains(d.SearchKey)
                || x.TitleEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Select(x => new
            {
                x.Id,
                x.TitleAr,
                x.TitleEn,
                createAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                x.CreatedAt,
                x.SliderType
            }).Skip(d.Start).Take(d.Length).ToList();
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = items };
            return Json(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateOneImg()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneImg(SliderDTO model)
        {
            if (ModelState.IsValid)
            {
                var slider = _Mapper.Map<CMSCar.Areas.CPanel.Models.Sliders.Slider>(model);

                slider.MainImage = await ImageHelper.SaveImage(model.MainImages, _environment, "Images/Slider");
                slider.SliderType = Models.SliderType.OneImage;
                _Context.Slider.Add(slider);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderDTO model)
        {
            if (ModelState.IsValid)
            {
                var slider = _Mapper.Map<CMSCar.Areas.CPanel.Models.Sliders.Slider>(model);

                slider.MainImage = await ImageHelper.SaveImage(model.MainImages, _environment, "Images/Slider");
                slider.Image1 = await ImageHelper.SaveImage(model.Images1, _environment, "Images/Slider");
                slider.Image2 = await ImageHelper.SaveImage(model.Images2, _environment, "Images/Slider");
                slider.Image3 = await ImageHelper.SaveImage(model.Images3, _environment, "Images/Slider");
                slider.Image4 = await ImageHelper.SaveImage(model.Images3, _environment, "Images/Slider");
                _Context.Slider.Add(slider);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var slider = _Context.Slider.Find(id);
            if (slider == null) return NotFound();
            
            var sliderDTO = _Mapper.Map<SliderDTO>(slider);
            return View(sliderDTO);
        }
        [HttpGet]
        public IActionResult EditOneImg(int? id)
        {
            if (id == null) return NotFound();
            var slider = _Context.Slider.Find(id);
            if (slider == null) return NotFound();
            var sliderDTO = _Mapper.Map<SliderDTO>(slider);
            return View(sliderDTO);
        }
        [HttpPost]
        public async Task<IActionResult> EditOneImg(SliderDTO model)
        {
            if (ModelState.IsValid)
            {
                var slider = _Mapper.Map<CMSCar.Areas.CPanel.Models.Sliders.Slider>(model);
                var orgOffer = _Context.Slider.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                if (model.MainImages != null)
                { slider.MainImage = await ImageHelper.SaveImage(model.MainImages, _environment, "Images/Slider"); }
                else { slider.MainImage = orgOffer.MainImage; }
           
                slider.CreatedAt = orgOffer.CreatedAt;
                slider.SliderType = orgOffer.SliderType;
                _Context.Slider.Update(slider);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SliderDTO model)
        {
            if (ModelState.IsValid)
            {
                var slider = _Mapper.Map<CMSCar.Areas.CPanel.Models.Sliders.Slider>(model);
                var orgOffer = _Context.Slider.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                if (model.MainImages != null)
                { slider.MainImage = await ImageHelper.SaveImage(model.MainImages, _environment, "Images/Slider"); }
                else { slider.MainImage = orgOffer.MainImage; }
                if (model.Images1 != null)
                { slider.Image1 = await ImageHelper.SaveImage(model.Images1, _environment, "Images/Slider"); }
                else { slider.Image1 = orgOffer.Image1; }
                if (model.Images2 != null)
                { slider.Image2 = await ImageHelper.SaveImage(model.Images2, _environment, "Images/Slider"); }
                else { slider.Image2 = orgOffer.Image2; }
                if (model.Images3 != null)
                { slider.Image3 = await ImageHelper.SaveImage(model.Images3, _environment, "Images/Slider"); }
                else { slider.Image3 = orgOffer.Image3; }
                if (model.MainImages != null)
                { slider.Image4 = await ImageHelper.SaveImage(model.Images4, _environment, "Images/Slider"); }
                else { slider.Image4 = orgOffer.Image4; }
                slider.CreatedAt = orgOffer.CreatedAt;
                _Context.Slider.Update(slider);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int? Id)
        {
            if (Id == null) return NotFound();
            var slider = _Context.Slider.Find(Id);
            if (slider == null) return NotFound();
            _Context.Slider.Remove(slider);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}
