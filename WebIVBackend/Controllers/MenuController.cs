using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebIVBackend.Domain.Models;
using WebIVBackend.Domain.Repositories;

namespace WebIVBackend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        
        private MenuRepository _menus;

        public MenuController(MenuRepository menus)
        {
            _menus = menus;
        }

        [HttpPost]
        public ActionResult<string> CreateMenu(Menu m)
        {
            _menus.AddMenu(m);

            return CreatedAtAction(nameof(GetMenu), new {id = m.Id}, m);
        }
        
        
        // GET
        [HttpGet]
        public IList<Menu> GetMenus()
        {
            return _menus.GetAll();
        }
        
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Menu> GetMenu(string id)
        {
            Menu menu = _menus.GetMenu(id);
            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }
        
        [HttpPut]
        public ActionResult<Menu> EditProduct(Menu m, string id)
        {
            Menu menu = _menus.GetMenu(id);
            menu.Title = m.Title;
            menu.Description = m.Description;
            
            return _menus.UpdateMenu(menu);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(string id)
        {
            Menu menu = _menus.GetMenu(id);
            if (menu == null)
            {
                return NotFound();
            }
            _menus.DeleteMenu(id);
            return NoContent();
        }
    }
}