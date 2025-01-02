using dizajni_i_sistemit_softuerik.Domain.Entities;
using System.Threading.Tasks;

namespace dizajni_i_sistemit_softuerik.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> RegisterUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
    }
}