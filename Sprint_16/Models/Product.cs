using System.Collections.Generic;

namespace Sprint_16.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
