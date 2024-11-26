// Repositories/PaymentRepository.cs
using dizajni_i_sistemit_softuerik.Entities;
using Microsoft.EntityFrameworkCore;
using dizajni_i_sistemit_softuerik.Data;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAll() => _context.Payments.ToList();

        public Payment GetById(int id) => _context.Payments.Find(id);

        public void Add(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void Update(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Payment> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Payments
                        .Where(p => p.DateCreated >= startDate && p.DateCreated <= endDate)
                        .ToList();
        }

        public IEnumerable<Payment> GetByStatus(string status)
        {
            return _context.Payments
            .Where(p => p.Status == status)
            .ToList();
        }

        public IEnumerable<Payment> GetByPaymentMethod(string paymentMethod)
        {
            return _context.Payments
            .Where(p => p.PaymentMethod == paymentMethod)
            .ToList();
        }

        public IEnumerable<Payment> GetByClientId(int clientId)
        {
            return _context.Payments
            .Where(p => p.ClientId == clientId)
            .ToList();
        }
        public double GetTotalRevenue()
        {
            return _context.Payments.Sum(p => p.Amount);
        }
    }
}
