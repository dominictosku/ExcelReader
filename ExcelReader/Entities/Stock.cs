using ExcelReader.Entities.Enums;

namespace ExcelReader.Entities
{
	public class Stock
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string ISIN { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int Count { get; set; }
		public OrderType OrderType {  get; set; }
		public DateTime OrderDate { get; set; }
	}
}
