using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dizajni_i_sistemit_softuerik.Domain.Entities;
using dizajni_i_sistemit_softuerik.Services;
using dizajni_i_sistemit_softuerik.Services.Interfaces;

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

            var result = reservations.Select(r => new
            {
                r.Id,
                r.ClientName,
                r.ClientPhoneNumber,
                r.NumberOfGuests,
                r.ReservationDate,
                Status = r.Status
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> Get(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            var result = new
            {
                reservation.Id,
                reservation.ClientName,
                reservation.ClientPhoneNumber,
                reservation.NumberOfGuests,
                reservation.ReservationDate,
                Status = reservation.Status
            };

            return Ok(result);
        }

        [HttpGet("details/{secretId}")]
        public async Task<IActionResult> GetReservationDetails(string secretId)
        {
            var reservation = await _reservationService.GetBySecretIdAsync(secretId);
            if (reservation == null)
            {
                return NotFound(new { message = "Reservation not found" });
            }

            return Ok(new
            {
                reservation.ClientName,
                reservation.ClientPhoneNumber,
                reservation.NumberOfGuests,
                reservation.ReservationDate,
                Status = reservation.Status.ToString()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest();
            }

            reservation.SecretId = Guid.NewGuid().ToString();
            await _reservationService.CreateAsync(reservation);

            var reservationUrl = $"https://localhost:7117/reservation/{reservation.SecretId}";

            return CreatedAtAction(nameof(GetReservationDetails), new { secretId = reservation.SecretId }, new
            {
                reservation.SecretId,
                message = "Reservation successfully created",
                reservationUrl
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            var existingReservation = await _reservationService.GetByIdAsync(id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            await _reservationService.UpdateAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationService.DeleteAsync(id);
            return Ok(new { message = "Reservation deleted successfully" });
        }

        [HttpPut("confirm/{id}")]
        public async Task<IActionResult> ConfirmReservation(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.Status = "Confirmed";
            await _reservationService.UpdateAsync(reservation);
            return Ok(new { message = "Reservation confirmed successfully" });
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelReservation(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.Status = "Cancelled";
            await _reservationService.UpdateAsync(reservation);
            return Ok(new { message = "Reservation cancelled successfully" });
        }
    }
}
