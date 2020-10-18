using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Contact
{
    public class CallUsController : BaseController
    {
        public CallUsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.CallUs.Where(x => 
                (d.SearchKey == null
                || x.Name.Contains(d.SearchKey)
                || x.Phone.Contains(d.SearchKey)
                || x.Email.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<CallUsVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var callUs = _Context.CallUs.Find(id);
            if (callUs == null) return NotFound();
            return View(callUs);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var callUs = _Context.CallUs.Find(id);
            if (callUs == null) return NotFound();
            _Context.CallUs.Remove(callUs);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}
