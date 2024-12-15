namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        // Navigation property for Users
        public ICollection<User> Users { get; set; }

        // Navigation property for RolePermission
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
