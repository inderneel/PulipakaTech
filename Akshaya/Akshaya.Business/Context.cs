using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akshaya.Business.Entities;

namespace Akshaya.Business
{
    public class Context : DbContext
    {
        public Context(string connectionStringName) : base(connectionStringName)
        {
            /*Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());*/
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());

            ConfigureEntities();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PriceChange> PriceChanges { get; set; }

/*        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(order => order.CreatedByUserId)
                .IsRequired();


        }*/

        private void ConfigureEntities()
        {
            //var productTypeConfiguration = new EntityTypeConfiguration<Product>();

            //productTypeConfiguration.HasKey(product => product.Code);
        }
    }
}
