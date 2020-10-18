using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.DTOs;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Areas.CPanel.ViewModels;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.User
{
    public class UserController : BaseController
    {
        private IWebHostEnvironment _environment;
        private RoleManager<IdentityRole> _roleManager;
        public UserController(RoleManager<IdentityRole> roleManager ,IWebHostEnvironment environment ,UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
            _environment = environment;
            _roleManager = roleManager;
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
            var query = _Context.Users.Where(x =>
                (d.SearchKey == null
                || x.FullName.Contains(d.SearchKey)
                || x.Email.Contains(d.SearchKey)
                || x.PhoneNumber.Contains(d.SearchKey))).OrderBy(x => x.CreatedAt);
            int totalCount = query.Count();
            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var itemsVM = _Mapper.Map<List<UserVM>>(items);
            var result = new { draw = d.Draw, recordsTotal = totalCount, recordsFiltered = totalCount, data = itemsVM };
            return Json(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _Mapper.Map<ApplicationUser>(model);
                user.UserName = model.Email;
                user.IsActive = true;
                user.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/User");
                var result = await _userManager.CreateAsync(user , model.Password);
                if (!result.Succeeded)
                {
                    return Content(ResultMessage.FailedResult(), "application/json");
                }
                return Content(ResultMessage.AddSuccessResult(), "application/json");
            }
            return View();
        }

        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = _Context.Users.Find(id);
            if (user == null) return NotFound();

            return View(_Mapper.Map<UserDTO>(user));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserDTO model , string id)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                user.UserName = model.Email;
                user.NormalizedUserName = model.Email.ToUpper();
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
                user.PhoneNumber = model.PhoneNumber;
                user.FullName = model.FullName;
            
                if (model.Image != null)
                {
                    user.ImagePath = await ImageHelper.SaveImage(model.Image, _environment, "Images/User");
                }
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return Content(ResultMessage.FailedResult(), "application/json");
                }
                return Content(ResultMessage.EditSuccessResult(), "application/json");

            }
            return View();
        }


        public async Task<ActionResult> Delete(string Id)
        {
            if (Id == null) return NotFound();
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            if (user == null)return NotFound();
            _Context.Users.Remove(user);
            _Context.SaveChanges();
            return Content(ResultMessage.DeleteSuccessResult(), "application/json");
        }


        [HttpGet]
        public async Task<ActionResult> Activate(string Id, bool Active)
        {
            if (Id == null) return NotFound();
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                user.IsActive = Active;
                _Context.SaveChanges();
                return Content(ResultMessage.StatusUpdateResult(), "application/json");
            }
            else
                return Content(ResultMessage.FailedResult(), "application/json");
        }
        [HttpGet]
        public async Task<ActionResult> AddAdmin(string Id, bool Active)
        {
            if (Id == null) return NotFound();
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                if (Active)
                {
                    if (!await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        var result = await _userManager.AddToRoleAsync(user, "Admin");
                        if (result.Succeeded) return Content(ResultMessage.StatusUpdateResult(), "application/json");
                        else return Content(ResultMessage.FailedResult(), "application/json");
                    }
                    else return Content(ResultMessage.FailedResult(), "application/json");

                }
                else
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
                        if (result.Succeeded) return Content(ResultMessage.StatusUpdateResult(), "application/json");
                        else return Content(ResultMessage.FailedResult(), "application/json");
                    }
                    else return Content(ResultMessage.FailedResult(), "application/json");

                }

            }
            else return Content(ResultMessage.FailedResult(), "application/json");
        }



    }
}
