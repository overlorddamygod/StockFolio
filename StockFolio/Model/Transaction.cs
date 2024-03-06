namespace StockFolio.Model
{
    public enum TransactionType
    {
        Buy,
        Sell
    }
    public class Transaction
    {
        public Int64 Id { get; set; }
        public int StockId { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 Price { get; set; }
        public int UserId { get; set; }
        public TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public Int64 Sold { get; set; }
        public Int64 Profit { get; set; }
        public Stock? Stock { get; set; }
    }
}
