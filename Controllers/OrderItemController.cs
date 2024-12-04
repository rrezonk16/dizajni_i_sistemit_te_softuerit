using Microsoft.AspNetCore.Mvc;
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderItem>> Get() => Ok(_orderItemService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<OrderItem> Get(int id)
        {
            var orderItem = _orderItemService.GetById(id);
            return orderItem != null ? Ok(orderItem) : NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] OrderItem orderItem)
        {
            _orderItemService.Create(orderItem);
            return CreatedAtAction(nameof(Get), new { id = orderItem.Id }, orderItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id) return BadRequest();
            _orderItemService.Update(orderItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderItemService.Delete(id);
            return NoContent();
        }
    }
}
