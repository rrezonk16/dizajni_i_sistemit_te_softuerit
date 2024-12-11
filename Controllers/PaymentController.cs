using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;
using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("ByDateRange")]
        public ActionResult<IEnumerable<Payment>> GetByDateRange(DateTime startDate,
            DateTime endDate) => Ok(_paymentService.GetByDateRange(startDate, endDate));

        [HttpGet("ByStatus")]
        public ActionResult<IEnumerable<Payment>> GetByStatus(string status) => Ok(_paymentService.GetByStatus(status));

        [HttpGet("ByPaymentMethod")]
        public ActionResult<IEnumerable<Payment>> GetByPaymentMethod(string paymentMethod) => Ok(_paymentService.GetByPaymentMethod(paymentMethod));

        [HttpGet("ByClientId")]
        public ActionResult<IEnumerable<Payment>> GetByClientId(int clientId) => Ok(_paymentService.GetByClientId(clientId));

        [HttpGet("{id}")]
        public ActionResult<Payment> GetById(int id)
        {
            var payment = _paymentService.GetById(id);
            return payment != null ? Ok(payment) : NotFound();
        }

        [HttpGet("TotalRevenue")]
        public double GetTotalRevenue()
        {
            var revenue = _paymentService.GetTotalRevenue();
            return revenue;
        }

        [HttpPost]
        public ActionResult Add([FromBody] Payment payment)
        {
            _paymentService.Add(payment);
            return CreatedAtAction(nameof(Add), new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Payment payment)
        {
            if (id != payment.Id) return BadRequest();
            _paymentService.Update(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _paymentService.Delete(id);
            return NoContent();
        }
    }
}
