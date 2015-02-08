using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Akshaya.Business;
using Akshaya.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Business
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void GenerateTables()
        {
            using (var ctx = new Context("Akshaya"))
            {
                var prod = new Product { Code = "FIRST", Description = "TEST"};
                ctx.Products.Add(prod);
                ctx.SaveChanges();
            }
        }

        [TestMethod]
        public void AddCustomer()
        {
            using (var ctx = new Context("Akshaya"))
            {
                var customers = 
                    new List<Customer>
                    {
                        new Customer { Firstname = "Test", Lastname = "Customer"},
                        new Customer { Firstname = "Second", Lastname = "Customer"},
                        new Customer { Firstname = "Third", Lastname = "Customer"},
                    };

                customers.ForEach(s => ctx.Customers.AddOrUpdate(p => p.Lastname, s));
                
                ctx.SaveChanges();
            }
        }
    }
}
