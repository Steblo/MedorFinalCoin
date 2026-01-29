namespace DC.Models
{
    namespace DC.Models
    {
        public class CryptoRateDto
        {
            public required string Instrument { get; set; }   // např. BTC-EUR
            public decimal Price { get; set; }       // aktuální cena
            public DateTime RetrievedAt { get; set; } = DateTime.UtcNow;
        }
    }
}