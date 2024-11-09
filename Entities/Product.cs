using System.ComponentModel.DataAnnotations;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
    }
}
