using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set;}
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Client Client { get; set; }

    }
}
