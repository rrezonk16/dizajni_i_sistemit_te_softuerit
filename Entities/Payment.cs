using System.ComponentModel.DataAnnotations.Schema;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Payment : BaseEntity
    {
        public int ClientId { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Currency { get; set; }
        public double DiscountApplied { get; set; } 
        public string Status { get; set; }
    }
}
