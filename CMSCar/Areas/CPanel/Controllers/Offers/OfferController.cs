using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.SpecialOffers;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Offers
{
    public class OfferController : BaseController
    {
        private IWebHostEnvironment _environment;
        public OfferController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.Offer.Where(x =>
                (d.SearchKey == null
                || x.NameAr.Contains(d.SearchKey)
                || x.NameEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<OfferVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public IActionResult Create()
        {
            ViewData["Cars"] = new SelectList(_Context.Car, "Id", "NameAr");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OfferDTO model)
        {
            if (ModelState.IsValid)
            {
                var offer = _Mapper.Map<Offer>(model);
                offer.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/Offer");
                _Context.Offer.Add(offer);
                _Context.SaveChanges();
                if (model.OfferCarIds.Any())
                {
                    foreach (var item in model.OfferCarIds)
                    {
                        OfferCar offerCar = new OfferCar();
                        offerCar.CarId = item;
                        offerCar.OfferId = offer.Id;
                        _Context.OfferCar.Add(offerCar);
                    }
                    _Context.SaveChanges();

                }
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            ViewData["Cars"] = new SelectList(_Context.Car, "Id", "NameAr");
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var offer = _Context.Offer.Find(id);
            if (offer == null) return NotFound();
            ViewData["Cars"] = new SelectList(_Context.Car, "Id", "NameAr");
            var offerDTO = _Mapper.Map<OfferDTO>(offer);
            offerDTO.OfferCarIds = _Context.OfferCar.Where(x => x.OfferId == id).Select(m => m.CarId).ToList();
            return View(offerDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OfferDTO model)
        {
            if (ModelState.IsValid)
            {
                var offer = _Mapper.Map<Offer>(model);
                var orgOffer = _Context.Offer.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                if (model.Image != null)
                { offer.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/Offer"); }
                else { offer.ImagePath = orgOffer.ImagePath; }
                offer.CreatedAt = orgOffer.CreatedAt;
                _Context.Offer.Update(offer);
                _Context.SaveChanges();
                if (model.OfferCarIds.Any())
                {
                    foreach (var item in _Context.OfferCar.Where(x=> x.OfferId == orgOffer.Id).ToList())
                    {
                        _Context.OfferCar.Remove(item);
                    }
                    _Context.SaveChanges();
                    foreach (var item in model.OfferCarIds)
                    {
                        OfferCar offerCar = new OfferCar();
                        offerCar.CarId = item;
                        offerCar.OfferId = orgOffer.Id;
                        _Context.OfferCar.Add(offerCar);
                    }
                    _Context.SaveChanges();
                }
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            ViewData["Cars"] = new SelectList(_Context.Car, "Id", "NameAr");
            return View();
        }


        public ActionResult Delete(int? Id)
        {
            if (Id == null) return NotFound();
            var offer = _Context.Offer.Find(Id);
            if (offer == null) return NotFound();
            _Context.Offer.Remove(offer);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}
