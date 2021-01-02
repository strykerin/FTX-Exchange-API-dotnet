namespace FTX.Entities
{
    public class Market
    {
        /// <summary>
        /// e.g. "BTC/USD" for spot, "BTC-PERP" for futures
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Spot markets only
        /// </summary>
        public string BaseCurrency { get; set; }
        /// <summary>
        /// spot markets only
        /// </summary>
        public string QuoteCurrency { get; set; }
        /// <summary>
        /// "future" or "spot"
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Future markets only
        /// </summary>
        public string Underlying { get; set; }
        public bool Enabled { get; set; }
        /// <summary>
        /// Best ask
        /// </summary>
        public decimal Ask { get; set; }
        /// <summary>
        /// Best bid
        /// </summary>
        public decimal Bid { get; set; }
        /// <summary>
        /// Last traded price
        /// </summary>
        public decimal Last { get; set; }
        /// <summary>
        /// If the market is in post-only mode (all orders get modified to be post-only, in addition to other settings they may hve)
        /// </summary>
        public bool PostOnly { get; set; }
        public decimal PriceIncrement { get; set; }
        public decimal SizeIncrement { get; set; }
        /// <summary>
        /// If the market has nonstandard restrictions on which jurisdictions can trade it
        /// </summary>
        public bool Restricted { get; set; }
    }
}
