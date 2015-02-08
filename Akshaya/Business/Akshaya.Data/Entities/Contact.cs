namespace Akshaya.Data.Entities
{
    public class Contact : IContact
    {
        public long Id { get; set; }
        public string ContactType { get; set; }
        public string ContactInfo { get; set; }
    }

    public interface IContact : IBusinessEntity
    {
        long Id { get; set; }
        string ContactType { get; set; }
        string ContactInfo { get; set; }
    }

    public static class ContactTypes
    {
        public static string Email = "Email";
        public static string Address = "Address";
        public static string Phone = "Phone";
    }
}