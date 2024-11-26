using System.Collections.Generic;
using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IReservationService 
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);
        Task CreateAsync (Reservation reservation);
        Task UpdateAsync (Reservation reservation);
        Task DeleteAsync (int id);
    }
}
