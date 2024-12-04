using dizajni_i_sistemit_softuerik.Data;
using dizajni_i_sistemit_softuerik.Entities;
using Microsoft.EntityFrameworkCore;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .ToList();
        }

        public OrderItem GetById(int id)
        {
            return _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .FirstOrDefault(oi => oi.Id == id);
        }

        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public void Update(OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                _context.SaveChanges();
            }
        }
    }
}
