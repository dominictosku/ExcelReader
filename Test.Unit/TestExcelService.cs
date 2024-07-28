using ExcelReader.Entities;
using ExcelReader.Entities.Enums;
using ExcelReader.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Unit
{
    public class TestExcelService
    {
        [Fact]
        public void TestReadExcelFile() 
        {
            //assert
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"TestData\Stock.xlsx";
            string filePath = Path.Combine(baseDir, relativePath);
            List<Transactions> expectedStocks = new List<Transactions>
            {
                new() { Id = 1, Stock = new Stock(){ Name = "MSFT", ISIN = "US5949181045" }, Price = 300, Count = 1, OrderType = OrderType.Buy, OrderDate = new DateTime(2023, 1, 3) },
                new() { Id = 2, Stock = new Stock(){ Name = "MSFT", ISIN = "US5949181045" }, Price = 343, Count = 2, OrderType = OrderType.Buy, OrderDate = new DateTime(2023, 7, 21) },
                new() { Id = 3, Stock = new Stock(){ Name = "AAPL", ISIN = "US0378331005" }, Price = 171, Count = 1, OrderType = OrderType.Buy, OrderDate = new DateTime(2023, 10, 25) },
                new() { Id = 4, Stock = new Stock(){ Name = "AAPL", ISIN = "US0378331005" }, Price = 190, Count = 2, OrderType = OrderType.Buy, OrderDate = new DateTime(2024, 5, 30) },
                new() { Id = 5, Stock = new Stock(){ Name = "MSFT", ISIN = "US5949181045" }, Price = 429, Count = 3, OrderType = OrderType.Sell, OrderDate = new DateTime(2024, 5, 30) }
            };

            // Ensure the file exists to avoid file not found errors
            Assert.True(File.Exists(filePath), "Test data file does not exist: " + filePath);

            // Open the file in read mode with FileStream
            byte[] fileData = File.ReadAllBytes(filePath);
            var excelService = new ExcelService();

            //act
            var result = excelService.ReadExcelFile(SupportedBroker.Swissquote, fileData);
            Assert.NotNull(result);
            result = [.. result.OrderBy(x => x.Stock.Name)];
            expectedStocks = [.. result.OrderBy(x => x.Stock.Name)];

            //assert
            Assert.Equal(expectedStocks.Count, result.Count);
            Assert.Equal(expectedStocks.First(), result.First());
        }
    }
}
