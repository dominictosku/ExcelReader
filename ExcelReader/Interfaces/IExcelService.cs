using ExcelReader.Entities;

namespace ExcelReader.Interfaces
{
    public interface IExcelService
    {
        List<Stock> ReadExcelFile(byte[] fileData);
    }
}