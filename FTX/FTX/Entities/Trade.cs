using System;

namespace FTX.Entities
{
    public class Trade
    {
        public long Id { get; set; }
        public bool Liquidation { get; set; }
        public decimal Price { get; set; }
        public string Side { get; set; }
        public decimal Size { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
