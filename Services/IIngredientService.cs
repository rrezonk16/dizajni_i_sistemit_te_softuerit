using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient GetById(int id);
        void Create(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(int id);
    }
}