using Microsoft.AspNetCore.Mvc;
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() => Ok(_productService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productService.GetById(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Product product)
        {
            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            if (id != product.Id) return BadRequest();
            _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
