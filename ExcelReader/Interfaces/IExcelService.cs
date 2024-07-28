using ExcelReader.Entities;
using ExcelReader.Entities.Enums;

namespace ExcelReader.Interfaces
{
    public interface IExcelService
    {
        List<Transactions> ReadExcelFile(SupportedBroker supportedBroker, byte[] fileData);
    }
}