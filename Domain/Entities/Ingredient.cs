using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dizajni_i_sistemit_softuerik.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public string Category { get; set; }
    }
}
