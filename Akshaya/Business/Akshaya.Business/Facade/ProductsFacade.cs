using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akshaya.AppEntities.Entities;
using Akshaya.Data.Entities;
using Akshaya.Transformers.Transformers;

namespace Akshaya.Business.Facade
{
    public class ProductsFacade : FacadeBase, IFacade
    {
        private readonly ProductTransformer _transformer;

        public ProductsFacade()
        {
            _transformer = new ProductTransformer();
        }

        public override ModelBase Get(long id)
        {
            var product = Context.Products.SingleOrDefault(p => p.Id == id);
            var model = _transformer.GetProductModel(product);

            return model;
        }

        public override IList<ModelBase> GetAll()
        {
            var products = Context.Products;
            var model = _transformer.GetProductModels(products.ToList());

            var result = new List<ModelBase>();

            foreach(var product in model)
            {
                result.Add(product);
            }

            return result;
        }

        public override bool Add(ModelBase model)
        {
            var products = Context.Products;
            var newProduct = model as ProductModel;

            if(newProduct != null)
            {
                /*if(products.Any(p => p.Code == newProduct.Code))
                {
                    return false;
                }*/

                var newEntity = new Product
                {
                    BuyingPrice = newProduct.BuyingPrice,
                    Code = newProduct.Code,
                    CurrentlyAvailable = newProduct.CurrentlyAvailable,
                    Description = newProduct.Description,
                    UnitPrice = newProduct.UnitPrice,
                    Name =  newProduct.Name
                };                

                Context.Products.Add(newEntity);

                Context.SaveChanges();
                
                return true;
            }

            return false;
        }
        
        public override void Update(ModelBase model)
        {
            var product = model as ProductModel;

            if(product != null)
            {
                var existingProduct = Context.Products.FirstOrDefault(p => p.Id == product.Id);

                if(existingProduct != null)
                {
                    existingProduct.BuyingPrice = product.BuyingPrice;
                    existingProduct.Code = product.Code;
                    existingProduct.CurrentlyAvailable = product.CurrentlyAvailable;
                    existingProduct.Description = product.Description;
                    existingProduct.UnitPrice = product.UnitPrice;
                    existingProduct.Name = product.Name;
                }
                
                Context.SaveChanges();
            }
        }
    }
}
