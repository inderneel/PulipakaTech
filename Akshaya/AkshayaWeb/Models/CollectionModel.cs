using System.IO;
using System.Web;

namespace AkshayaWeb.Models
{
    public class CollectionModel
    {
        private readonly HttpServerUtilityBase _server;

        public CollectionModel(HttpServerUtilityBase server)
        {
            _server = server;
        }

        public void GetImages()
        {
            var imagesPath = "~/App_Data/Collection";

            DirectoryInfo diFile
                = new DirectoryInfo(_server.MapPath("~/Images/"));
        }
    }
}