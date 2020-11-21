using AutoMapper;
using CMSCar.Areas.CPanel.Models.Notfication;
using CMSCar.Areas.CPanel.Models.User;
using CMSCar.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCar.Areas.CPanel.Controllers.Notfication
{
    public class NotificationController : BaseController
    {
        public NotificationController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }

        // GET: Admin/_Context
        public async Task<IActionResult> AllNotifications()
        {
            return View(await _Context.Notifications.OrderByDescending(x=> x.SendAt).ToListAsync());
        }

        public IActionResult getCountNotification()
        {
            return Json(_Context.Notifications.Where(x => x.IsRead == false).Count());
        }
        public void ChangeNotification()
        {
            List<Notifications> items = _Context.Notifications.Where(x =>  x.IsRead == false).ToList();
            foreach (var item in items)
            {
                item.IsRead = true;
                _Context.Update(item);
            }
            _Context.SaveChanges();
        }

    }
}
