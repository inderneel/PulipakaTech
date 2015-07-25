namespace Akshaya.Data.Entities
{
    public class Picture
    {
        public long Id { get; set; }
        public byte[] PictureData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}