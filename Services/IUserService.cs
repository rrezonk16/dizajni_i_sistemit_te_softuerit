using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string name, string surname, string email, string password, string phoneNumber, string address);
        Task<User> LoginAsync(string email, string password);
        Task<User> GetUserByIdAsync(int userId);

    }
}
