using System.Collections.Generic;
using System.Linq;
using Akshaya.AppEntities.Entities;
using Akshaya.Data.Entities;

namespace Akshaya.Business.Facade
{
    public class PicturesCacheFacade: FacadeBase, IFacade
    {
        public override bool Add(ModelBase model)
        {
            var pictureModel = model as PictureCacheModel;
            
            if (pictureModel == null || string.IsNullOrEmpty(pictureModel.Name))
            {
                return false;
            }

            var picture = new PictureCache()
            {
                Name = pictureModel.Name
            };

            Context.PicturesInCache.Add(picture);
            Context.SaveChanges();

            pictureModel.PictureCacheId = picture.Id;

            return true;
        }
    }
}