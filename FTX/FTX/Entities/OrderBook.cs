using System.Collections.Generic;

namespace FTX.Entities
{
    public class OrderBook
    {
        public List<List<decimal>> Asks { get; set; }
        public List<List<decimal>> Bids { get; set; }
    }
}
