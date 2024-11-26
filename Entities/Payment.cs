using System.ComponentModel.DataAnnotations;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? OrderId { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Currency { get; set; }
        public double DiscountApplied { get; set; } 
        public string Status { get; set; }

        // public Order Order { get; set; } 
        public Client Client { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}
