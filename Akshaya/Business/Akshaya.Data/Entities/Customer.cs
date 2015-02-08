using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya.Data.Entities
{
    public class Customer : ICustomer
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }

    public interface ICustomer : IBusinessEntity
    {
        long Id { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }

        ICollection<Contact> Contacts { get; set; }
    }
}
