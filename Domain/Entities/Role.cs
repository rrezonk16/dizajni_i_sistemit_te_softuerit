using dizajni_i_sistemit_softuerik.Dtos;

namespace dizajni_i_sistemit_softuerik.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
