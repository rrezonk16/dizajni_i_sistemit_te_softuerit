using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
