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
        public ActionResult<string> Index()
        {
            return "yeet";
        }
    }
}