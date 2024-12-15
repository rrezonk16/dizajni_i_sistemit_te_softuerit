namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Permission : BaseEntity
    {
        public string PermissionName { get; set; }

        // Navigation property for RolePermission
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
