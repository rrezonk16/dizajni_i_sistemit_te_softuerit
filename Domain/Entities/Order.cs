using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int ClientId { get; set;}

        public int PaymentId { get; set;}     
        
        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }
    }
}
