using dizajni_i_sistemit_softuerik.Domain.Entities;

public interface IRoleRepository
{
    Task<Role> GetRoleByUserIdAsync(int userId);
}