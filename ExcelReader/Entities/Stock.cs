namespace ExcelReader.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ISIN { get; set; } = string.Empty;
    }
}
