using System.Collections.Generic;

namespace Sprint_16.Models
{
    public class SuperMarket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
