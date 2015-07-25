namespace Akshaya.AppEntities.Entities
{
    public class PictureModel : ModelBase
    {
        public long Id { get; set; }
        public byte[] PictureData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}