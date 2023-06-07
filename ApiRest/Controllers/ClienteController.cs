using Authentication;
using Customer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Cliente> Get()
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.getClientes();
            return clientes;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("Dni/{dni}")]
        [Authorize]
        public IActionResult Get(long dni)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            Cliente cliente = clienteRepository.getCliente(dni);
            return Ok(cliente);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("Id/{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            Cliente cliente = clienteRepository.getCliente(id);
            return Ok(cliente);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Cliente value)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            CustomerService customerService = new CustomerService();
            if(value.Cuit != null)
            {
                var validateCuit = customerService.ValidateCUIT((long)value.Cuit);
                if (!validateCuit)
                    return BadRequest(new { message = "Fallo la validacion de cuit" });
            }
            clienteRepository.addCliente(value);
            return Ok(new { message = "Cliente creado"});
        }
    }
}
