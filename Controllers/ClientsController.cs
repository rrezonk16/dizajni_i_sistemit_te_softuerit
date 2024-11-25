using Microsoft.AspNetCore.Mvc;
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get() => Ok(_clientService.GetAll());


        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = _clientService.GetById(id);
            return client != null ? Ok(client) : NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Client client)
        {
            _clientService.Create(client);
            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Client client)
        {
            if (id != client.Id) return BadRequest();
            _clientService.Update(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientService.Delete(id);
            return NoContent();
        }
    }
}
