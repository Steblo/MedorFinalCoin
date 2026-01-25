namespace DC.Models
{
    public class CoinDeskResponse
    {
        public Dictionary<string, CoinDeskTick> Data { get; set; }
    }

    public class CoinDeskTick
    {
        public decimal Price { get; set; }
        public long Timestamp { get; set; }
    }

}
