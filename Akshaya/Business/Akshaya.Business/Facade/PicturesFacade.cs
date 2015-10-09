using System.Collections.Generic;
using System.Linq;
using Akshaya.AppEntities.Entities;
using Akshaya.Data.Entities;

namespace Akshaya.Business.Facade
{
    public class PicturesFacade: FacadeBase, IFacade
    {
        public override bool Add(ModelBase model)
        {
            var pictureModel = model as PictureModel;
            var product = Context.Products.SingleOrDefault(p => p.Id == pictureModel.ProductId);

            if (product == null)
            {
                return false;
            }

            var picture = new Picture()
            {
                Description = pictureModel.Description,
                Name = pictureModel.Name,
                //PictureData = pictureModel.PictureData
            };

            if(product.Pictures == null)
                product.Pictures = new List<Picture>();

            product.Pictures.Add(picture);

            Context.SaveChanges();

            return true;
        }
    }
}