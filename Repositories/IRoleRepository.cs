using dizajni_i_sistemit_softuerik.Entities;

public interface IRoleRepository
{
    Task<Role> GetRoleByUserIdAsync(int userId);
}