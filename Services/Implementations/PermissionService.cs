using System.Collections.Generic;
using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.Domain.Entities;
using dizajni_i_sistemit_softuerik.Repositories.Interfaces;
using dizajni_i_sistemit_softuerik.Services.Interfaces;

namespace dizajni_i_sistemit_softuerik.Services.Implementations
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(int roleId)
        {
            // Fetch permissions by role ID logic
            var permissions = await _permissionRepository.GetByRoleIdAsync(roleId);

            return permissions ?? new List<Permission>(); // If null, return an empty list
        }
    }
}
