using ExcelReader.Entities;
using ExcelReader.Entities.Enums;

namespace ExcelReader.Interfaces
{
    public interface IExcelService
    {
        List<Stock> ReadExcelFile(SupportedBroker supportedBroker, byte[] fileData);
    }
}