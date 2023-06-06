using Authentication;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        // POST api/<LoginController>
        [HttpPost("autenticacion")]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UsuarioAcceso value)
        {
            var userService = new UserService();
            var response = userService.Authenticate(value);
            if(response == null)
            {
                return BadRequest(new {Message = "Credenciales incorrectas"});
            }
            return Ok(response);
        }
    }
}
