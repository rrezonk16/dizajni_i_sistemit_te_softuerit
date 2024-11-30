using dizajni_i_sistemit_softuerik.Entities;
using System.Threading.Tasks;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> RegisterUserAsync(User user);
    }
}
