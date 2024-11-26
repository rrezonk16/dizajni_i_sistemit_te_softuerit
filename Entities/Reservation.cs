using System;
using System.ComponentModel.DataAnnotations;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Reservation 
    {
    [Key]
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int TableId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string Status { get; set; }
        
    }
}
