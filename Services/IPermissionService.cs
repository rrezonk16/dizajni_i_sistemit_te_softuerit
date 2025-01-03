using System.Collections.Generic;
using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId);
    }
}
