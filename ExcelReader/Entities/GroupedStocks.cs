namespace ExcelReader.Entities
{
    public class GroupedStocks
    {
        public GroupedStocks(List<Stock> stocks) 
        {
            Name = stocks[0].Name;
            ISIN = stocks[0].ISIN;
            Stocks = stocks;
        }

        public string Name { get; set; }
        public string ISIN { get; set; }
        public List<Stock> Stocks { get; set; }
        public int Count => Stocks.Count;
    }
}
