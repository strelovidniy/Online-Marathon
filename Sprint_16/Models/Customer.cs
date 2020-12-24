using System.Collections.Generic;

namespace Sprint_16.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address{ get; set; }
        public decimal? Discount { get; set; }

        public List<Order> Orders { get; set; }
    }
}
