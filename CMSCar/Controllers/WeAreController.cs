using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCar.Data;
using Microsoft.AspNetCore.Mvc;

namespace CMSCar.Controllers
{
    public class WeAreController   : BaseController
    {
        public WeAreController(ApplicationDbContext context) : base(context)
        {
        }

        public IActionResult Vision()
        {
            var model = _Context.WhoWeAre.FirstOrDefault();
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = _Context.WhoWeAre.FirstOrDefault();
            return View(model);
        }

        public IActionResult Conditions()
        {
            var model = _Context.WhoWeAre.FirstOrDefault();
            return View(model);
        }
    }
}
