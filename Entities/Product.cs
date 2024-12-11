using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int? StockQuantity { get; set; }
        public string Description { get; set; }
        public decimal? Volume { get; set; }
        public string? Temperature { get; set; } // hot, cold
        public bool? IsCarbonated { get; set; }
        public string? Ingredients { get; set; }
        public string? MealType { get; set; }
    }
}
