using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya.Business.Entities
{
    public class PriceChange
    {
        public int Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public float PreviousPrice { get; set; }
        public float CurrentPrice { get; set; }
        
        public User ChangeBy { get; set; }
        public Product Product { get; set; }
    }
}
