using dizajni_i_sistemit_softuerik.Entities;

namespace dizajni_i_sistemit_softuerik.Services
{
    public interface IPaymentService
    {
        Payment GetById(int id);
        IEnumerable<Payment> GetByDateRange(
            DateTime startDate,
            DateTime endDate
        );
        IEnumerable<Payment> GetByStatus(string status);
        IEnumerable<Payment> GetByPaymentMethod(string paymentMethod);
        IEnumerable<Payment> GetByClientId(int clientId);
        double GetTotalRevenue();
        void Add(Payment Payment);
        void Update(Payment Payment);
        void Delete(int id);
    }
}