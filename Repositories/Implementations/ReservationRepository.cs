using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dizajni_i_sistemit_softuerik.Database;
using dizajni_i_sistemit_softuerik.Domain.Entities;
using dizajni_i_sistemit_softuerik.Repositories.Interfaces;

namespace dizajni_i_sistemit_softuerik.Repositories.Implementations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.AsNoTracking().ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reservation> GetBySecretIdAsync(string secretId)
        {
            return await _context.Reservations.AsNoTracking().FirstOrDefaultAsync(r => r.SecretId == secretId);
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
