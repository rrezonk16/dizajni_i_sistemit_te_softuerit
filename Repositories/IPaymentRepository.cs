using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Repositories
{
    public interface IPaymentRepository
    {
        Payment GetById(int id);
        IEnumerable<Payment> GetByDateRange(
            DateOnly startDate,
            DateOnly endDate
        );
        IEnumerable<Payment> GetByStatus(string status);
        IEnumerable<Payment> GetByPaymentMethod(string paymentMethod);
        IEnumerable<Payment> GetByClientId(int clientId);
        Payment GetByOrderId(int orderId);
        decimal GetTotalRevenue();
        void Add(Payment Payment);
        void Update(Payment Payment);
        void Delete(int id);
    }
}