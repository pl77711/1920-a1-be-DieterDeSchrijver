using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebIVBackend.Domain.Models;
using WebIVBackend.Domain.Services;

namespace WebIVBackend.Controllers
{
    [ApiController]
    [Route("auth/")]
    public class AuthenticationController : Controller
    {
        private AdminService _as;
        
        public AuthenticationController(AdminService adminService)
        {
            _as = adminService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginRequest login)
        {
            if(!_as.EmailAlreadyUsed(login.Email))
                return BadRequest("This email is not connected to an account");
            if (_as.AuthorizeAdmin(login))
            {
                return Ok(JsonSerializer.Serialize(_as.GetToken(login.Email)));
            }
            return BadRequest("Email and password do not match");
        }

        [HttpGet]
        [Route("{id}")]
        public Admin GetAdmin(string id)
        {
            return _as.GetAdmin(id);
        }
    }
}