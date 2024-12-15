using System.ComponentModel.DataAnnotations.Schema;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Order : BaseEntity
    {
        public int ClientId { get; set; }

        public int PaymentId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        
        public Payment Payment { get; set; }
    }
}
