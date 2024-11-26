using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;
using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get() => Ok(_orderService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = _orderService.GetById(id);
            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Order order)
        {
            _orderService.Create(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            if (id != order.Id) return BadRequest();
            _orderService.Update(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return NoContent();
        }
    }
}
