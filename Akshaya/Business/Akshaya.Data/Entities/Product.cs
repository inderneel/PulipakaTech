using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya.Data.Entities
{
    public class Product : IProduct
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public float BuyingPrice { get; set; }
        public float UnitPrice { get; set; }
        public int CurrentlyAvailable { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }

    public interface IProduct : IBusinessEntity
    {
        long Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        float BuyingPrice { get; set; }
        float UnitPrice { get; set; }
        int CurrentlyAvailable { get; set; }
        ICollection<Picture> Pictures { get; set; }
    }
}
