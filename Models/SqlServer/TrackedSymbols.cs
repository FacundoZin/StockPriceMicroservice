namespace StockPriceMicroservice.Models.SqlServer
{
    public class TrackedSymbols
    {
        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public string Symbol { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;


        public WebSocketConnection WebSocketConnection { get; set; }
    }
}
