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

namespace CMSCar.Areas.CPanel.Controllers.PurchaseOrders
{
    public class IndiviualController : BaseController
    {
        public IndiviualController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }
        public IActionResult CashIndex()
        {
            return View();
        }
        public JsonResult CashAjaxData([FromBody] dynamic data)
        {
            DataTableHelper d = new DataTableHelper(data);
            string jsonString = data.ToString();
            JObject ss = JObject.Parse(jsonString);
            var query = _Context.IndividualCash.Where(x =>
                (d.SearchKey == null
                || x.Name.Contains(d.SearchKey)
                || x.Phone.Contains(d.SearchKey)
                || x.CarName.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<IndividualCashVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public ActionResult CashDetails(int? id)
        {
            if (id == null) return NotFound();
            var individualCash = _Context.IndividualCash.Find(id);
            if (individualCash == null) return NotFound();
            return View(individualCash);
        }

        public ActionResult CashDelete(int? id)
        {
            if (id == null) return NotFound();
            var individualCash = _Context.IndividualCash.Find(id);
            if (individualCash == null) return NotFound();
            _Context.IndividualCash.Remove(individualCash);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}
