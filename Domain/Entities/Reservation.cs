using dizajni_i_sistemit_softuerik.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace dizajni_i_sistemit_softuerik.Domain.Entities
{

    public class Reservation : BaseEntity
    {
        public string ClientName { get; set; }
        public string ClientPhoneNumber { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        public String Status { get; set; } ="Pending";

        public string SecretId { get; set; } = Guid.NewGuid().ToString();
    }
}
