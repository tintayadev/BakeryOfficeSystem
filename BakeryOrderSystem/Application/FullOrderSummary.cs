namespace BakeryProject.Application
{
    public class FullOrderSummary
    {
        public int ActiveOrdersCount { get; set; }
        public decimal ActiveOrdersRevenue { get; set; }
        public int HistoricalOrdersCount { get; set; }
        public decimal HistoricalOrdersRevenue { get; set; }
        public int TotalOrdersCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
