using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
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
        private AllergyRepository _allergies;

        public MenuController(MenuRepository menus, AllergyRepository allergies)
        {
            _menus = menus;
            _allergies = allergies;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public ActionResult<Menu> CreateMenu(MenuToCreate m)
        {
            Menu menu = new Menu(m.Title, m.Description);
            if (m.Allergies.Count == 0)
            {
            }
            else
            {
                foreach (var allergy in m.Allergies)
                {
                    menu.Allergies.Add(_allergies.GetById(allergy));
                }
            }

            if (m.ImageSrc == null || m.ImageSrc.Equals(""))
            {
                menu.ImageSrc = "template";
            }
            else
            {
                menu.ImageSrc = m.ImageSrc;
            }
            
            _menus.AddMenu(menu);

            return menu;
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

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public ActionResult<Menu> PutRecipe(MenuToCreate m, string id)
        {
            Menu menu = new Menu(m.Title, m.Description);
            menu.Id = id;
            if (m.Allergies.Count == 0)
            {
            }
            else
            {
                foreach (var allergy in m.Allergies)
                {
                    menu.Allergies.Add(_allergies.GetById(allergy));
                }
            }
            
            return _menus.UpdateMenu(menu);
        }

        [Authorize(Policy = "AdminOnly")]
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

        [HttpGet]
        [Route("/api/allergies")]
        public IList<Allergy> GetAllergies()
        {
            IList<Allergy> allergies = _allergies.GetAll();
            return allergies;
        }
    }
}