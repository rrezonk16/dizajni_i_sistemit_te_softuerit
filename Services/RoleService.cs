namespace dizajni_i_sistemit_softuerik.Services
{
  
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<string> GetUserRoleAsync(int userId)
        {
            var role = await _roleRepository.GetRoleByUserIdAsync(userId);
            return role?.Name ?? "Role not found";
        }
    }
}
