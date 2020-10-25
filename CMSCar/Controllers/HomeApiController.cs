using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCar.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSCar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HomeApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetWhyUs()
        {
            var query = _context.WhyUs.Where(x=> x.OrderBy != 0);
            var items = query.Select(x => new
            {
                x.Id,
                x.NameAr,
                x.NameEn,
                x.ImagePath,
                x.DescrptionAr,
                x.DescrptionEn,
                x.CreatedAt,
            }).OrderByDescending(x => x.CreatedAt).Take(3).ToList();
            return (items);
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetTypeCar()
        {
            var query = _context.CarType;
            var items = query.Select(x => new
            {
                x.Id,
                x.NameAr,
                x.NameEn,
                x.ImagePath,
                x.CreatedAt,
            }).OrderByDescending(x => x.CreatedAt).ToList();
            return (items);
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetCar()
        {
            var query = _context.Car;
            var items = query.Select(x => new
            {
                x.Id,
                x.NameAr,
                x.NameEn,
                x.ShowImage,
                x.CreatedAt,
            }).OrderByDescending(x => x.CreatedAt).ToList();
            return (items);
        }
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetOffer()
        {
            var query = _context.Offer;
            var items = query.Select(x => new
            {
                x.Id,
                x.NameAr,
                x.NameEn,
                x.ImagePath,
                x.CreatedAt,
            }).OrderByDescending(x => x.CreatedAt).ToList();
            return (items);
        } 
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetFaq()
        {
            var query = _context.Question;
            var items = query.Select(x => new
            {
                x.Id,
                x.QuestionAr,
                x.QuestionEn,
                x.AnswerAr,
                x.AnswerEn,
                x.CreatedAt,
            }).OrderByDescending(x => x.CreatedAt).ToList();
            return (items);
        }
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetBanks()
        {
            var query = _context.FininceSide;
            var items = query.Select(x => new
            {
                x.ImagePath,
                x.CreatedAt,
            }).OrderByDescending(x => x.CreatedAt).ToList();
            return (items);
        }
    }
}
