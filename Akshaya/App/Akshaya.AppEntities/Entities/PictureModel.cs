using System.Web;

namespace Akshaya.AppEntities.Entities
{
    public class PictureModel : ModelBase
    {
        public long PictureId { get; set; }
        public long Id { get; set; }
        public string PictureData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ProductId { get; set; }
    }
}