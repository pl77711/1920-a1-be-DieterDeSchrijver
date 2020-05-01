using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebIVBackend.Domain.Models;
using WebIVBackend.Domain.Repositories;

namespace WebIVBackend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    [Route("api/[controller]")]
    public class DayController : Controller
    {
        
        private DayRepository _days;
        private MenuRepository _menus;

        public DayController(DayRepository days, MenuRepository menus)
        {
            _days = days;
            _menus = menus;
        }
        
        // GET
        [HttpGet]
        public IList<Day> GetDays()
        {
            return _days.GetAll();
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Day> GetDay(string id)
        {
            Day day = _days.GetDay(id);
            if (day == null)
            {
                return NotFound();
            }

            return day;
        }
        
        [HttpPost]
        public ActionResult<Day> CreateDay(DayToCreate d)
        {
            Menu menu = _menus.GetMenu(d.menu);
            Day day = new Day(d.date, d.maxUsers, menu);
            
            _days.AddDay(day);

            return day;
        }
    }
}