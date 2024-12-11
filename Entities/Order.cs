using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Order : BaseEntity
    {
        public int ClientId { get; set;}

        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }
        public Client Client { get; set; }
    }
}
