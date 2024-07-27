namespace ExcelReader.Entities
{
	public class BrokerStocks(string name, List<Stock> stocks)
	{
		public int Id { get; set; }
		public string Name { get; set; } = name;
		public List<Stock> Stocks { get; set; } = stocks;
	}
}
