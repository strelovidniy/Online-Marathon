using System;
using System.Collections.Generic;

namespace Sprint_16.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SuperMarketId { get; set; }
        public SuperMarket SuperMarket { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
