using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebIVBackend.Data;
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
        private UserRepository _users;

        public DayController(DayRepository days, MenuRepository menus, UserRepository users)
        {
            _days = days;
            _menus = menus;
            _users = users;
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
        
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public ActionResult<Day> CreateDay(DayToCreate d)
        {
            Menu menu = _menus.GetMenu(d.menu);
            Day day = new Day(d.date, d.maxUsers, menu);
            
            _days.AddDay(day);

            return day;
        }
        
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDay(string id)
        {
            Day day = _days.GetDay(id);
            if (day == null)
            {
                return NotFound();
            }

            _days.DeleteDay(id);
            return NoContent();
        }
        
        [HttpPost]
        [Route("/api/register")]
        public IActionResult Register(UserToRegister userToRegister)
        {
            if (!_days.Excist(userToRegister.DayIds))
            {
                return BadRequest();
            }

            List<Day> days = _days.GetMultipleDays(userToRegister.DayIds);
            foreach (var day in days)
            {
                User u = _users.GetUser(userToRegister.Email);

                try
                {
                    if (u != null)
                    {
                        day.AddUser(u);
                        _users.UpdateUser(u);
                        _days.UpdateDay(day);
                    }
                    else
                    {
                        u = new User(userToRegister.FirstName, userToRegister.LastName, userToRegister.Email);
                        day.AddUser(u);
                        _users.AddUser(u);
                        _days.UpdateDay(day);
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                
            }

            return StatusCode(200);
        }
        
    }
}