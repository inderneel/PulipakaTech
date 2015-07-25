using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akshaya.AppEntities.Entities;
using Akshaya.Data.Entities;

namespace Akshaya.Transformers.Transformers
{
    public class ProductTransformer: TransformerBase, ITransformer
    {
        public ProductModel GetProductModel(Product product)
        {
            return AutoMapper.Mapper.Map<ProductModel>(product);
        }

        public IList<ProductModel> GetProductModels(IList<Product> products)
        {
            var result = new List<ProductModel>();

            foreach(var product in products)
            {
                result.Add(GetProductModel(product));
            }

            return result;
        }
    }
}
