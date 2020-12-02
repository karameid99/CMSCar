using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

    }
}
