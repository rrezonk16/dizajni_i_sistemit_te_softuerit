using System.Data;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Foreign key for Role
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
