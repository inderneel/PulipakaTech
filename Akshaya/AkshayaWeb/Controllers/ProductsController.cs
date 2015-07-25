using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Akshaya.AppEntities.Entities;
using Akshaya.Business.Facade;

namespace AkshayaWeb.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductsFacade _productsFacade;

        public ProductsController()
        {
            _productsFacade = new ProductsFacade();
        }

        [HttpGet]
        public ModelBase GetProduct(long id)
        {
            var model = _productsFacade.Get(id);

            return model;
        }

        [HttpGet]
        public IEnumerable<ModelBase> GetAllProducts()
        {
            var model = _productsFacade.GetAll();

            return model;
        }

        [HttpPost]
        public void AddProduct(ProductModel product)
        {
            _productsFacade.Add(product);
        }
    }
}
