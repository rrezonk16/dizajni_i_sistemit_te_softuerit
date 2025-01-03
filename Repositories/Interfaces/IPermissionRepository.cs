using System.Collections.Generic;
using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.Domain.Entities;

namespace dizajni_i_sistemit_softuerik.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<IEnumerable<Permission>> GetByRoleIdAsync(int roleId); 
        Task AddAsync(Permission permission);
        Task UpdateAsync(Permission permission);
        Task DeleteAsync(int id);
    }
}
