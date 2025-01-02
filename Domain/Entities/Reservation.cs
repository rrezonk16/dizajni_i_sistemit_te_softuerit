using System;
using System.ComponentModel.DataAnnotations;

namespace dizajni_i_sistemit_softuerik.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public int ClientId { get; set; }
        public int TableId { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; }

    }
}
