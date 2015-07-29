using System;
using System.Data.Entity;
using MangoEasy.Library.Models;
using MangoEasy.Library.Services;

namespace MangoEasy.Service
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MongoDbApiDataContext : DbContext, IDataContext
    {
        //public MangoDevDataContext() { }
        //public MangoDevDataContext(string connStringName) : base(connStringName) { }
        //static MangoDevDataContext ()
        //{
        //    // static constructors are guaranteed to only fire once per application.
        //    // I do this here instead of App_Start so I can avoid including EF
        //    // in my MVC project (I use UnitOfWork/Repository pattern instead)
        //    //DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        //}
       
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
