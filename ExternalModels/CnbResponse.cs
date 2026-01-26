namespace DC.ExternalModels
{
    public class CnbResponse
    {
        public DateTime Date { get; set; }          // Datum platnosti kurzů
        public required string BankName { get; set; }        // Název banky (např. "ČNB")
        public required List<CnbRate> Rates { get; set; }    // Seznam kurzů jednotlivých měn
    }

    public class CnbRate
    {
        public required string Country { get; set; }         // Země (např. "USA")
        public required string Currency { get; set; }        // Název měny (např. "dolar")
        public required string Code { get; set; }            // ISO kód měny (např. "USD")
        public int Amount { get; set; }             // Množství (např. 1, 100)
        public decimal Rate { get; set; }           // Kurz vůči CZK
    }
}
