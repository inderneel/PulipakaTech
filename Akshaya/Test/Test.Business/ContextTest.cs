using System;
using Akshaya.Business;
using Akshaya.Business.Entities;
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
    }
}
