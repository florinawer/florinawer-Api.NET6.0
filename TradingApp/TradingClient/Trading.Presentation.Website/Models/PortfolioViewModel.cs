namespace Trading.Presentation.Website.Models
{
    public class PortfolioViewModel
    {
        public PortfolioViewModel()
        {

        }
        public int Amount { get; set; }
        public int BuyPrice { get; set; }
        public StockViewModel? Stock { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
