using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMSCar.Areas.CPanel.Models.Mails;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using CMSCar.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CMSCar.Areas.CPanel.Controllers.Mails
{
    public class MailController : BaseController
    {
        public MailController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }


        public IActionResult Index()
        {
            ViewData["ListMails"] = new SelectList(_Context.Mail, "Email", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(string[] listEmail, string Title, string Message)
        {
            ModelState.Remove("CreatedAt");
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in listEmail)
                    {
                        await SendEmail.SendMailAsync(item, Title, Message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return Content(ResultMessage.SendSuccessResult(), "application/json");

            }
            return Content(ResultMessage.FailedResult(), "application/json");

        }

        public JsonResult AjaxData([FromBody] dynamic data)
        {
            DataTableHelper d = new DataTableHelper(data);
            string jsonString = data.ToString();
            JObject ss = JObject.Parse(jsonString);

            var query = _Context.Mail.Where(x => (d.SearchKey == null
               || x.Email.Contains(d.SearchKey))).OrderByDescending(p => p.CreatedAt).ToList();

            int totalCount = query.Count();

            var items = query.Select(x => new
            {
                x.Id,
                x.Email,
                createdAt = x.CreatedAt.ToString("MM/dd/yyyy"),
            }).Skip(d.Start).Take(d.Length).ToList();
            var result =
               new
               {
                   draw = d.Draw,
                   recordsTotal = totalCount,
                   recordsFiltered = totalCount,
                   data = items
               };
            return Json(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mail mail)
        {

            if (ModelState.IsValid)
            {
                _Context.Add(mail);
                await _Context.SaveChangesAsync();
                return Content(ResultMessage.AddSuccessResult(), "application/json");

            }
            return View(mail);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = await _Context.Mail.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }
            return View(mail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mail mail)
        {
            if (id != mail.Id)
            {
                return NotFound();
            }
            ModelState.Remove("CreatedAt");
            ModelState.Remove("CategoryId");
            if (ModelState.IsValid)
            {
                try
                {
                    _Context.Update(mail);
                    await _Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MailExists(mail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new
                {
                    status = 1,
                    msg = "s: تمت عملية التعديل بنجاح",
                    close = 1
                });
            }
            return View(mail);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Mail mail = _Context.Mail.Single(x => x.Id.Equals(id));

            if (mail == null)
            {
                return NotFound();
            }
            _Context.Remove(mail);
            _Context.SaveChanges();

            return Json(new
            {
                status = 1,
                msg = "w: تمت عملية الحذف بنجاح",
                close = 1
            });
        }

        private bool MailExists(int id)
        {
            return _Context.Mail.Any(e => e.Id == id);
        }

    }
}
