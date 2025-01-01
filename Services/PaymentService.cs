using System;
using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Repositories;

namespace dizajni_i_sistemit_softuerik.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;  
    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    public void Add(Payment Payment) => _paymentRepository.Add(Payment);

    public void Delete(int id) => _paymentRepository.Delete(id);

    public IEnumerable<Payment> GetByClientId(int clientId) => _paymentRepository.GetByClientId(clientId);
    public Payment GetByOrderId(int orderId) => _paymentRepository.GetByOrderId(orderId);
    public IEnumerable<Payment> GetByDateRange(DateOnly startDate, DateOnly endDate) => _paymentRepository.GetByDateRange(startDate, endDate);

    public Payment GetById(int id) => _paymentRepository.GetById(id);

    public IEnumerable<Payment> GetByPaymentMethod(string paymentMethod) => _paymentRepository.GetByPaymentMethod(paymentMethod);
    public IEnumerable<Payment> GetByStatus(string status) => _paymentRepository.GetByStatus(status);
    public decimal GetTotalRevenue() => _paymentRepository.GetTotalRevenue();
    public void Update(Payment Payment) => _paymentRepository.Update(Payment);
}
