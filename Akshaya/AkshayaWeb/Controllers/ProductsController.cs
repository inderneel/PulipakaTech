using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Akshaya.AppEntities.Entities;
using Akshaya.Business.Facade;

namespace AkshayaWeb.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductsFacade _productsFacade;
        private readonly PicturesFacade _picturesFacade;
        private readonly PicturesCacheFacade _picturesCacheFacade;

        public ProductsController()
        {
            _productsFacade = new ProductsFacade();
            _picturesFacade = new PicturesFacade();
            _picturesCacheFacade = new PicturesCacheFacade();
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
        public void SaveProduct(ProductModel product)
        {
            if (product.Id == 0)
            {
                _productsFacade.Add(product);
            }
            else
            {
                _productsFacade.Update(product);
            }
        }

        [HttpPost]
        public void SaveImageInfo(PictureModel picture)
        {
            if (picture.ProductId == 0)
            {
                throw new Exception("Invalid picture Id.");
            }

            _picturesFacade.Add(picture);
        }

        /*[HttpPost]
        public PictureCacheModel SaveImage()
        {*/

        public async Task<HttpResponseMessage> SaveImage()
        {
            /*
                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new MultipartMemoryStreamProvider();
                    await Request.Content.ReadAsMultipartAsync(streamProvider);
                    var pictureCacheModel = new PictureCacheModel();

                    foreach (var file in streamProvider.Contents)
                    {
                        var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                        var buffer = await file.ReadAsByteArrayAsync();

                        pictureCacheModel.Name = filename;
                        _picturesCacheFacade.Add(pictureCacheModel);

                        Stream fileStream = File.Create("c:/uploads/" + filename);
                        fileStream.Write(buffer,0,buffer.Length);
                        fileStream.Close();
                    }

                    var response = Request.CreateResponse(HttpStatusCode.OK, pictureCacheModel);

                    return response;
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable,
                        "This request is not properly formatted"));
                }*/

            var requestStream = await Request.Content.ReadAsStreamAsync();

            /*var requestStream = requestStreamTask.Result;*/
            var fileName = Guid.NewGuid().ToString();
            var pictureCacheModel = new PictureCacheModel();

            try
            {
                Stream fileStream = File.Create(@"C:\uploads\" + fileName + ".jpeg");
                requestStream.CopyTo(fileStream);
                fileStream.Close();
                requestStream.Close();
                pictureCacheModel.Name = fileName;
                _picturesCacheFacade.Add(pictureCacheModel);

                /*return pictureCacheModel;*/
                var response = Request.CreateResponse(HttpStatusCode.OK, pictureCacheModel);

                return response;
            }
            catch (IOException)
            {
                var httpResponseException = new  HttpResponseException(HttpStatusCode.InternalServerError);

                throw httpResponseException;
            }
            //_picturesFacade.Add(picture);
        }
    }
}
