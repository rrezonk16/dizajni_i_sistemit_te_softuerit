using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> Get(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            return reservation != null ? Ok(reservation) : NotFound(); 
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Reservation reservation)
        {
            await _reservationService.CreateAsync(reservation);
            return CreatedAtAction(nameof(Get), new { id = reservation.Id}, reservation);
        }
        
        [HttpPut("{id}")]
        public async Task <IActionResult> Update (int id, [FromBody] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }
            await _reservationService.UpdateAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            await _reservationService.DeleteAsync(id);
            return NoContent();
        }
      
    }
}
