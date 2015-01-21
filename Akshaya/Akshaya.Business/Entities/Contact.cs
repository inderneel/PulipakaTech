namespace Akshaya.Business.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactType { get; set; }
        public string ContactInfo { get; set; }
    }

    public static class ContactTypes
    {
        public static string Email = "Email";
        public static string Address = "Address";
        public static string Phone = "Phone";
    }
}