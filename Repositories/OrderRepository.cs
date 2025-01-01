using dizajni_i_sistemit_softuerik.Data;
using dizajni_i_sistemit_softuerik.Entities;
using System.Collections.Generic;
using System.Linq;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
        
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }


        public IEnumerable<Order> GetByDateRange(DateOnly startDate, DateOnly endDate)
        {
            return _context.Orders
                        .Where(p => p.CreatedAt >= startDate && p.CreatedAt <= endDate)
                        .ToList();
        }
    }
}
