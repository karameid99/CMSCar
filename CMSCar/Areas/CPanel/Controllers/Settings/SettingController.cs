using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.Settings;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSCar.Areas.CPanel.Controllers.Settings
{
    public class SettingController : BaseController
    {
        private IWebHostEnvironment _environment;
        public SettingController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            if (!InformationExists())
            {
                Information info = new Information();
                info.CreatedAt = DateTime.Now;
                _Context.Add(info);
                await _Context.SaveChangesAsync();
            }
            var information = await _Context.Information.FirstOrDefaultAsync();
            return View(information);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Information information, IFormFile Image, IFormFile SmallImage)
        {
            if (information == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    { information.Logo = await ImageHelper.SaveImage(Image, _environment, "Images/Information"); }
                    else
                    {
                        var information1 = await _Context.Information.AsNoTracking().FirstOrDefaultAsync();
                        information.Logo = information1.Logo;
                    }
                    if (SmallImage != null)
                    { information.SmallLogo = await ImageHelper.SaveImage(SmallImage, _environment, "Images/Information"); }
                    else
                    {
                        var information1 = await _Context.Information.AsNoTracking().FirstOrDefaultAsync();
                        information.SmallLogo = information1.SmallLogo;
                    }
                    _Context.Update(information);
                    await _Context.SaveChangesAsync();
                    ViewData["EditStatus"] = "تمت عملية التعديل بنجاح";
                    return View(information);

                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewData["EditStatus"] = "فشلت عملية التعديل";
                }
            }
            return View(information);
        }


        public async Task<IActionResult> TitlesIndex()
        {
            if (!TitlesExists())
            {
                Titles info = new Titles();
                info.CreatedAt = DateTime.Now;
                _Context.Add(info);
                await _Context.SaveChangesAsync();
            }
            var Titles = await _Context.Titles.FirstOrDefaultAsync();
            return View(Titles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TitlesIndex(Titles Titles)
        {
            if (Titles == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    _Context.Update(Titles);
                    await _Context.SaveChangesAsync();
                    ViewData["EditStatus"] = "تمت عملية التعديل بنجاح";
                    return View(Titles);

                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewData["EditStatus"] = "فشلت عملية التعديل";
                }
            }
            return View(Titles);
        }

        private bool TitlesExists()
        {
            return _Context.Titles.Any();
        }

        public async Task<IActionResult> WhoWeAreIndex()
        {
            if (!WhoWeAreExists())
            {
                WhoWeAre info = new WhoWeAre();
                info.CreatedAt = DateTime.Now;
                _Context.Add(info);
                await _Context.SaveChangesAsync();
            }
            var WhoWeAre = await _Context.WhoWeAre.FirstOrDefaultAsync();
            return View(WhoWeAre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WhoWeAreIndex(WhoWeAre WhoWeAre)
        {
            if (WhoWeAre == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                 
                    _Context.Update(WhoWeAre);
                    await _Context.SaveChangesAsync();
                    ViewData["EditStatus"] = "تمت عملية التعديل بنجاح";
                    return View(WhoWeAre);

                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewData["EditStatus"] = "فشلت عملية التعديل";
                }
            }
            return View(WhoWeAre);
        }

        private bool WhoWeAreExists()
        {
            return _Context.WhoWeAre.Any();
        }
        private bool InformationExists()
        {
            return _Context.Information.Any();
        }
    }
}
