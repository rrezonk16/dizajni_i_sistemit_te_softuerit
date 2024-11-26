using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Add(Order order); 
        void Update(Order order); 
        void Delete(int id); 
    }
}
