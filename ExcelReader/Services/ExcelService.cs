using ExcelReader.Entities;
using ExcelReader.Entities.Enums;
using ExcelReader.Interfaces;
using OfficeOpenXml;
namespace ExcelReader.Services
{
    public class ExcelService : IExcelService
    {
        public List<Stock> ReadExcelFile(SupportedBroker supportedBroker, byte[] fileData)
        {
            if(supportedBroker == SupportedBroker.Swissquote)
                return ReadSwissquoteFile(fileData);

            throw new NotSupportedException("This broker is not supported");
        }

        private List<Stock> ReadSwissquoteFile(byte[] fileData)
        {
            using (var stream = new MemoryStream(fileData))
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                var result = new List<Stock>();
                if (worksheet != null)
                {
                    int id = 1;
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var stock = new Stock
                        {
                            Id = id++,
                            Name = worksheet.Cells[row, 1].Text,
                            ISIN = worksheet.Cells[row, 2].Text,
                            OrderType = Enum.Parse<OrderType>(worksheet.Cells[row, 3].Text, true),
                            Count = int.Parse(worksheet.Cells[row, 4].Text),
                            Price = decimal.Parse(worksheet.Cells[row, 5].Text),
                            OrderDate = DateTime.Parse(worksheet.Cells[row, 6].Text)
                        };
                        result.Add(stock);
                    }
                }
                return result;
            }
        }
    }
}
