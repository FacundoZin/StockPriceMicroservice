namespace StockPriceMicroservice.Models.SqlServer
{
    public class WebSocketConnection
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
