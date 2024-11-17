using System.ComponentModel.DataAnnotations;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public string Category { get; set; }
    }
}
