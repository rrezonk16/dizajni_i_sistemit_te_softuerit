using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Repositories;

namespace dizajni_i_sistemit_softuerik.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public IEnumerable<OrderItem> GetAll() => _orderItemRepository.GetAll();

        public OrderItem GetById(int id) => _orderItemRepository.GetById(id);

        public void Create(OrderItem orderItem) => _orderItemRepository.Add(orderItem);

        public void Update(OrderItem orderItem) => _orderItemRepository.Update(orderItem);

        public void Delete(int id) => _orderItemRepository.Delete(id);
    }
}
