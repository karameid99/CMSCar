using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCar.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSCar.Areas.CPanel.Controllers.Notfication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotfiAPiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotfiAPiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetNotifications()
        {
            var query = _context.Notifications.Where(x => !x.IsRead);
            var items = query.Select(x => new
            {
                x.Id,
                x.Title,
                x.Body,
                x.SendAt,
                x.NotficationLink,
            }).OrderByDescending(x => x.SendAt).ToList();
            return (items);
        }
    }
}
