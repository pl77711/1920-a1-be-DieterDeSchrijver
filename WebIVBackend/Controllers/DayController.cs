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

        public DayController(DayRepository days)
        {
            _days = days;
        }
        
        // GET
        [HttpGet]
        public IList<Day> GetMenus()
        {
            return _days.GetAll();
        }
    }
}