using System;
using System.Data.Entity;
using MangoEasy.Library.Models;
using MangoEasy.Library.Models.Interfaces;
using MangoEasy.Library.Services;
using MySql.Data.Entity;

namespace MangoEasy.Test
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CodeFirstDbContext : DbContext, IDataContext
    {
        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<DevelopmentLanguage> DevelopmentLanguages { get; set; }
        IDbSet<TEntity> IDataContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries<IDtStamped>();

            foreach (var dtStamped in entities)
            {
                if (dtStamped.State == EntityState.Added)
                {
                    dtStamped.Entity.CreatedTime = DateTime.Now;
                }

                if (dtStamped.State == EntityState.Modified)
                {
                    dtStamped.Entity.UpdateTime = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CategoryMapping());
            //modelBuilder.Configurations.Add(new AvatarMapping());
            //modelBuilder.Configurations.Add(new LetterMapping());
            //modelBuilder.Configurations.Add(new RetailerMapping());
            //modelBuilder.Configurations.Add(new SiteMapping());           
            base.OnModelCreating(modelBuilder);
        }
    }
}
