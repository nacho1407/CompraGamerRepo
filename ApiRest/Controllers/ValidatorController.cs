using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidatorController : ControllerBase
    {
        // POST api/<ValidatorController>
        [HttpPost]
        public ValidCustomer Post([FromBody] ValidCustomer value)
        {
            return value;
        }
    }
}
