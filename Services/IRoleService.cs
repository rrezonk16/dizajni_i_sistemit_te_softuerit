using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IRoleService
    {
        Task<string> GetUserRoleAsync(int userId);
    }

}
