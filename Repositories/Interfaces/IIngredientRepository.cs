using dizajni_i_sistemit_softuerik.Domain.Entities;

namespace dizajni_i_sistemit_softuerik.Repositories.Interfaces
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