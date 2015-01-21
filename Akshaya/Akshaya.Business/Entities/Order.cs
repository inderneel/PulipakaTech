using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya.Business.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Date { get; set; }
        public int CreatedByUserId { get; set; }
        public int Total { get; set; }
    }
}
