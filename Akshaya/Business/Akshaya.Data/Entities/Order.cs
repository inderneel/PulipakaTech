using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya.Data.Entities
{
    public class Order : IOrder
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }

        [ForeignKey("CreatedBy")]
        public long CreatedByUserId { get; set; }
        public User CreatedBy { get; set; }

        [ForeignKey("Customer")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderProduct> Products { get; set; } 
    }

    public interface IOrder : IBusinessEntity
    {
        long Id { get; set; }
        DateTime Date { get; set; }
        float Total { get; set; }
        
        User CreatedBy { get; set; }
        Customer Customer { get; set; }
        
        ICollection<OrderProduct> Products { get; set; } 
    }
}
