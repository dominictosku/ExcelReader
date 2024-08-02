using ExcelReader.Entities.Enums;

namespace ExcelReader.Entities
{
	public class BrokerWallet(string name, List<Transactions> transactions)
	{
		public int Id { get; set; }
		public string Name { get; set; } = name;
		public List<Transactions> Transactions { get; set; } = transactions;

        public List<GroupedStocks> SummarizeStocksByYear(int year)
        {
            // Filter transactions by the specified year
            var filteredTransactions = Transactions.Where(t => t.OrderDate.Year == year);

            // Group transactions by Stock
            var groupedTransactions = filteredTransactions.GroupBy(t => t.Stock);

            // Summarize the transactions
            var summarizedStocks = new List<GroupedStocks>();
            foreach (var group in groupedTransactions)
            {
                var stock = group.Key;
                var netCount = group.Sum(t => t.OrderType == OrderType.Buy ? t.Count : -t.Count);

                if (netCount > 0)
                {
                    var stocks = Enumerable.Repeat(stock, netCount).ToList();
                    summarizedStocks.Add(new GroupedStocks(stocks));
                }
            }

            return summarizedStocks;
        }
    }
}
