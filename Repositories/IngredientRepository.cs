// Repositories/ProductRepository.cs
using dizajni_i_sistemit_softuerik.Entities;
using Microsoft.EntityFrameworkCore;
using dizajni_i_sistemit_softuerik.Data;
using dizajni_i_sistemit_softuerik.Repositories;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> GetAll() => _context.Ingredients.ToList();

        public Ingredient GetById(int id) => _context.Ingredients.Find(id);

        public void Add(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        public void Update(Ingredient ingredient)
        {
            _context.Entry(ingredient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
