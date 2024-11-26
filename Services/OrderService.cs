using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Repositories;

namespace dizajni_i_sistemit_softuerik.Services
{
    public class OrderService : IOrderService
    {
       
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        { 
        
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAll() => _orderRepository.GetAll();
        public Order GetById(int id) => _orderRepository.GetById(id);
        public void Create(Order order) => _orderRepository.Add(order);
        public void Update(Order order) => _orderRepository.Update(order); 
        public void Delete(int id) => _orderRepository.Delete(id);
    }
}
