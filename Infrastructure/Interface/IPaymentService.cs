using System.Threading.Tasks;
using Domain.Entity;
using PagarMe;

namespace Infrastructure.Interface
{
    public interface IPaymentService
    {
        Task Checkout();
        Task Refund();
        Task Refund(int amount);
        Task Refund(BankAccount bankAccount);
        Customer GetCustomerFromCompany(Company company);
    }
}