
using dizajni_i_sistemit_softuerik.Domain.Entities;
using dizajni_i_sistemit_softuerik.Repositories.Interfaces;
using dizajni_i_sistemit_softuerik.Services.Interfaces;

namespace dizajni_i_sistemit_softuerik.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll() => _productRepository.GetAll();

        public Product GetById(int id) => _productRepository.GetById(id);

        public void Create(Product product) => _productRepository.Add(product);

        public void Update(Product product) => _productRepository.Update(product);

        public void Delete(int id) => _productRepository.Delete(id);
    }
}