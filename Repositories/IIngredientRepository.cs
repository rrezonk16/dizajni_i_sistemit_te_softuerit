using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient GetById(int id);
        void Add(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(int id);
    }
}