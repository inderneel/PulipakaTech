using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
