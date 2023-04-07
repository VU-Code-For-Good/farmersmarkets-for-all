using ExcelDataReader;
using System.Data;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Dapper;
using FarmsMarketXMLReader.Models;
using Microsoft.Data.Sqlite;

namespace FarmsMarketXMLReader
{
    public class CSVMarketReader
    {
        private readonly string _csvPath;

        public CSVMarketReader(string csvPath)
        {
            _csvPath = csvPath;
        }

        public List<FarmersMarketRecord> ReadMarkets()
        {
            using (var reader = new StreamReader(_csvPath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                   {
                       HasHeaderRecord = false
                   }))
            {
                var records = csv.GetRecords<FarmersMarketRecord>();
                return records.Skip(1).ToList();
            }
        }
    }
}
