using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.Domain.Entities;

namespace dizajni_i_sistemit_softuerik.Services.Interfaces
{
    public interface IRoleService
    {
        Task<string> GetUserRoleAsync(int userId);
    }

}
