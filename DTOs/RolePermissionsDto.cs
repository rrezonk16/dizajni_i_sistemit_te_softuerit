using System.Collections.Generic;

namespace dizajni_i_sistemit_softuerik.Dtos
{
    public class RolePermissionsDto
    {
        /// <summary>
        /// The ID of the role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// The name of the role.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// A list of permissions associated with the role.
        /// </summary>
        public List<string> Permissions { get; set; }

        public RolePermissionsDto()
        {
            Permissions = new List<string>();
        }
    }
}
