
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Repositories;
using dizajni_i_sistemit_softuerik.Services;

namespace dizajni_i_sistemit_softuerik.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> GetAll() => _ingredientRepository.GetAll();

        public Ingredient GetById(int id) => _ingredientRepository.GetById(id);

        public void Create(Ingredient ingredient) => _ingredientRepository.Add(ingredient);

        public void Update(Ingredient ingredient) => _ingredientRepository.Update(ingredient);

        public void Delete(int id) => _ingredientRepository.Delete(id);
    }
}