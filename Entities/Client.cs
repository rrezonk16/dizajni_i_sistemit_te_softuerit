using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

