using System.Collections.Generic;

namespace TaskAuthenticationAuthorization.Models
{
    public class IndexViewModel
    {
        public IEnumerable<SuperMarket> SuperMarkets { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
