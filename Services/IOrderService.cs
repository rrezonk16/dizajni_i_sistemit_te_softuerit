using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Create(Order order); 
        void Update(Order order); 
        void Delete(int id); 
    }
}
