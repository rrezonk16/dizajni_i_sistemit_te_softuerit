using Microsoft.AspNetCore.Mvc;
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> Get() => Ok(_ingredientService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Ingredient> Get(int id)
        {
            var ingredient = _ingredientService.GetById(id);
            return ingredient != null ? Ok(ingredient) : NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Ingredient ingredient)
        {
            _ingredientService.Create(ingredient);
            return CreatedAtAction(nameof(Get), new { id = ingredient.Id }, ingredient);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Ingredient ingredient)
        {
            if (id != ingredient.Id) return BadRequest();
            _ingredientService.Update(ingredient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ingredientService.Delete(id);
            return NoContent();
        }
    }
}
