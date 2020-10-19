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

namespace CMSCar.Areas.CPanel.Controllers.PurchaseOrders
{
    public class CompanyController : BaseController
    {
        public CompanyController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
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
            var query = _Context.CompanyCash.Where(x =>
                (d.SearchKey == null
                || x.NameCompany.Contains(d.SearchKey)
                || x.Phone.Contains(d.SearchKey)
                || x.NamePerson.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<CashCompanyVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public ActionResult CashDetails(int? id)
        {
            if (id == null) return NotFound();
            var companyCash = _Context.CompanyCash.Include(x => x.carOrders).FirstOrDefault(m => m.Id == id);
            if (companyCash == null) return NotFound();
            return View(companyCash);
        }
        public ActionResult CashDelete(int? id)
        {
            if (id == null) return NotFound();
            var companyCash = _Context.CompanyCash.Find(id);
            if (companyCash == null) return NotFound();
            _Context.CompanyCash.Remove(companyCash);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }


        public IActionResult FinanceIndex()
        {
            return View();
        }
        public JsonResult FinanceAjaxData([FromBody] dynamic data)
        {
            DataTableHelper d = new DataTableHelper(data);
            string jsonString = data.ToString();
            JObject ss = JObject.Parse(jsonString);
            var query = _Context.CompanyFinance.Where(x =>
                (d.SearchKey == null
                || x.NameCompany.Contains(d.SearchKey)
                || x.Phone.Contains(d.SearchKey)
                || x.NamePerson.Contains(d.SearchKey)
                )).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<CompanyFinanceVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public ActionResult FinanceDetails(int? id)
        {
            if (id == null) return NotFound();
            var companyFinance = _Context.CompanyFinance.Include(x => x.carOrders).FirstOrDefault(m => m.Id == id);
            if (companyFinance == null) return NotFound();
            return View(companyFinance);
        }
        public ActionResult FinanceDelete(int? id)
        {
            if (id == null) return NotFound();
            var companyFinance = _Context.CompanyFinance.Find(id);
            if (companyFinance == null) return NotFound();
            _Context.CompanyFinance.Remove(companyFinance);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }
    }
}
