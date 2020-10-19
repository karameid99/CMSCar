using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.Questions;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Questions
{
    public class QuestionController : BaseController
    {
        public QuestionController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.Question.Where(x =>
                (d.SearchKey == null
                || x.QuestionAr.Contains(d.SearchKey)
                || x.QuestionEn.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<QuestionVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(QuestionDTO model)
        {
            if (ModelState.IsValid)
            {
                var Question = _Mapper.Map<Question>(model);
                _Context.Question.Add(Question);
                _Context.SaveChanges();
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var Question = _Context.Question.Find(id);
            if (Question == null) return NotFound();

            return View(_Mapper.Map<QuestionDTO>(Question));
        }
        [HttpPost]
        public IActionResult Edit(QuestionDTO model)
        {
            if (ModelState.IsValid)
            {
                var Question = _Mapper.Map<Question>(model);
                var orgQuestion = _Context.Question.AsNoTracking().SingleOrDefault(x => x.Id == model.Id);
                Question.CreatedAt = orgQuestion.CreatedAt;
                _Context.Question.Update(Question);
                _Context.SaveChanges();
                return Content(ResultMessage.EditSuccessResult(), "application/json");
            }
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var Question = _Context.Question.Find(id);
            if (Question == null) return NotFound();
            _Context.Question.Remove(Question);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }

    }
}
