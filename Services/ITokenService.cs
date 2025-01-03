using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Generates a JWT token for the given user.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        /// <returns>A string representing the JWT token.</returns>
        string GenerateToken(User user);

        /// <summary>
        /// Extracts the user ID from a given JWT token.
        /// </summary>
        /// <param name="token">The JWT token.</param>
        /// <returns>The user ID if found; otherwise, null.</returns>
        int? GetUserIdFromToken(string token);

        /// <summary>
        /// Extracts the role of the user from a given JWT token.
        /// </summary>
        /// <param name="token">The JWT token.</param>
        /// <returns>The role name if found; otherwise, null.</returns>
        string GetRoleFromToken(string token);
    }
}
