using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akshaya.Data.Entities;

namespace Akshaya.Business
{
    public class Context : DbContext
    {
        public Context(string connectionStringName) : base(connectionStringName)
        {
            /*Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());*/
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            /*Database.SetInitializer(new DropCreateDatabaseAlways<Context>());*/

            ConfigureEntities();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PriceChange> PriceChanges { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PictureCache> PicturesInCache { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(order => order.CreatedByUserId)
                .IsRequired();
        }

        private void ConfigureEntities()
        {
            //var productTypeConfiguration = new EntityTypeConfiguration<Product>();

            //productTypeConfiguration.HasKey(product => product.Code);
        }
    }
}
