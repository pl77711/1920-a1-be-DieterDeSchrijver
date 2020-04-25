﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebIVBackend.Domain.Models;
using WebIVBackend.Domain.Repositories;

namespace WebIVBackend.Controllers
{
    [ApiController]
    [Route("menu/")]
    public class MenuController : ControllerBase
    {
        
        private MenuRepository _menus;

        public MenuController(MenuRepository menus)
        {
            _menus = menus;
        }

        [HttpPost]
        public ActionResult<string> CreateMenu(string title, string description)
        {
            Menu menu = new Menu(title, description);
            _menus.AddMenu(menu);

            return "200 OK";
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
            return _menus.GetMenu(id);
        }
        
        [HttpPut]
        public ActionResult<Menu> EditProduct(Menu m, string id)
        {
            Menu menu = _menus.GetMenu(id);
            menu.Title = m.Title;
            menu.Description = m.Description;
            
            return _menus.UpdateMenu(menu);
        }
    }
}