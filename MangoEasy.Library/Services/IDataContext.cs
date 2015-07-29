using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MangoEasy.Library.Models;

namespace MangoEasy.Library.Services
{
   
    public interface IDataContext : IObjectContextAdapter, IDisposable
    {
        IDbSet<Account> Accounts { get; set; }
        IDbSet<Country> Countries { get; set; }
        IDbSet<Customer> Customers { get; set; }
        IDbSet<DevelopmentLanguage> DevelopmentLanguages { get; set; }
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
