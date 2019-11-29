using System.Threading.Tasks;
using Domain.Entity;
using Infrastructure.Interface;
using PagarMe;

namespace Infrastructure.Service
{
    public class PaymentService : IPaymentService
    {
        public Task Checkout() => throw new System.NotImplementedException();
        public Task Refund() => throw new System.NotImplementedException();
        public Task Refund(int amount) => throw new System.NotImplementedException();
        public Task Refund(BankAccount bankAccount) => throw new System.NotImplementedException();

        public Customer GetCustomerFromCompany(Company company)
        {
            var customerAddress = new Address()
            {
                Country = company.Country,
                State = company.State,
                City = company.City,
                Complementary = company.Complementary,
                Neighborhood = company.Neighborhood,
                Street = company.Street,
                StreetNumber = company.StreetNumber,
                Zipcode = company.ZipCode
            };

            var document = new Document()
            {
                Type = DocumentType.Cnpj,
                Number = company.Document
            };

            var customer = new Customer()
            {
                Name = company.Name,
                Address = customerAddress,
                Email = company.Email,
                Type = CustomerType.Corporation,
                Documents = new[] {document}
            };

            return customer;
        }
    }
}