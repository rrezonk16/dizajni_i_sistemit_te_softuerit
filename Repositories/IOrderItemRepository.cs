using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetAll();
        OrderItem GetById(int id);
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(int id);
    }
}
