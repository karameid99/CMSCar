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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Services
{
    public class ServiceOrderController : BaseController
    {
        public ServiceOrderController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.ServiceOrder.Include(x=> x.Service).Where(x =>
                (d.SearchKey == null|| x.Name.Contains(d.SearchKey)));
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).OrderByDescending(x => x.CreatedAt).ToList();
            var itemsVM = _Mapper.Map<List<ServiceOrderVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var serviceOrder = _Context.ServiceOrder.Find(id);
            if (serviceOrder == null) return NotFound();
            return View(serviceOrder);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var service = _Context.ServiceOrder.Find(id);
            if (service == null) return NotFound();
            _Context.ServiceOrder.Remove(service);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}
