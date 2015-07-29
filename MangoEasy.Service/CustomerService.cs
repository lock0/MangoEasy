using System;
using System.Linq;
using MangoEasy.Library.Models;
using MangoEasy.Library.Services;

namespace MangoEasy.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
         public CustomerService(MangoEasyDataContext dbContext)
             : base(dbContext)
        {
        }
         public void Insert(Customer customer)
         {
             DbContext.Customers.Add(customer);
             DbContext.SaveChanges();
         }

         public void Update()
         {
             DbContext.SaveChanges();
         }

         public void Delete(Guid id)
         {
             var model = GetCustomer(id);
             DbContext.Customers.Remove(model);
             DbContext.SaveChanges();
         }

         public Customer GetCustomer(Guid id)
         {
             return DbContext.Customers.FirstOrDefault(n => n.Id == id);
         }

         public IQueryable<Customer> GetCustomers()
         {
             return DbContext.Customers;
         }


         public Account GetAccount(Guid id)
         {
             return DbContext.Accounts.FirstOrDefault(n => n.Id == id);
         }
    }
}

