using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IOrderItemService
    {
        IEnumerable<OrderItem> GetAll();
        OrderItem GetById(int id);
        void Create(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(int id);
    }
}
