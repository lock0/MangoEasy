using System;
using System.Linq;
using MangoEasy.Library.Models;

namespace MangoEasy.Library.Services
{
    public interface ICustomerService : IDisposable
    {
        void Insert(Customer customer);
        void Update();
        void Delete(Guid id);
        Customer GetCustomer(Guid id);
        IQueryable<Customer> GetCustomers();
        Account GetAccount(Guid id);
    }
}
