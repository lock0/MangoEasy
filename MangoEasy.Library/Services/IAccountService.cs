using System;
using System.Linq;
using MangoEasy.Library.Models;

namespace MangoEasy.Library.Services
{
    public interface IAccountService : IDisposable
    {
        void Insert(Account account);
        void Update();
        void Delete(Guid id);
        Account GetAccount(Guid id);
        IQueryable<Account> GetAccounts();
        Account GetAccount(string email);
    }
}
