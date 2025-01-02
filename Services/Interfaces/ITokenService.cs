using dizajni_i_sistemit_softuerik.Domain.Entities;

namespace dizajni_i_sistemit_softuerik.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
