using ExcelDataReader;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace FarmsMarketXMLReader
{
    public class XmlReader
    {
        string fileLocation = "C:\\Users\\cody.martin\\Downloads\\SNAPauthorizedFMsSeptember2022.xlsx";
        public XmlReader()
        {
            
        }

        public void ReadFile()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(fileLocation, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        // Gets or sets a value indicating whether to set the DataColumn.DataType 
                        // property in a second pass.
                        UseColumnDataType = true,

                        // Gets or sets a callback to determine whether to include the current sheet
                        // in the DataSet. Called once per sheet before ConfigureDataTable.
                        FilterSheet = (tableReader, sheetIndex) => true,

                        // Gets or sets a callback to obtain configuration options for a DataTable. 
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            // Gets or sets a value indicating the prefix of generated column names.
                            EmptyColumnNamePrefix = "Column",

                            // Gets or sets a value indicating whether to use a row from the 
                            // data as column names.
                            UseHeaderRow = false,

                            // Gets or sets a callback to determine which row is the header row. 
                            // Only called when UseHeaderRow = true.
                            ReadHeaderRow = (rowReader) => {
                                // F.ex skip the first row and use the 2nd row as column headers:
                                rowReader.Read();
                            },

                            // Gets or sets a callback to determine whether to include the 
                            // current row in the DataTable.
                            FilterRow = (rowReader) => {
                                return true;
                            },

                            // Gets or sets a callback to determine whether to include the specific
                            // column in the DataTable. Called once per column after reading the 
                            // headers.
                            FilterColumn = (rowReader, columnIndex) => {
                                return true;
                            }
                        }
                    });
                    List<Market> markets = new List<Market>();
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow item in table.Rows)
                        {
                            if (item.ItemArray[5] == "State" || item.ItemArray[5].ToString() == string.Empty) continue;

                            markets.Add(new Market
                            {
                                StoreName = item.ItemArray[0].ToString(),
                                StreetNumber = item.ItemArray[1].ToString(),
                                StreetName = item.ItemArray[2].ToString(),
                                StreetName2 = item.ItemArray[3].ToString(),
                                City = item.ItemArray[4].ToString(),
                                State = item.ItemArray[5].ToString(),
                                ZipCode = item.ItemArray[6].ToString(),
                                CountyName = item.ItemArray[7].ToString(),
                            });
                        }
                    }
                    var b = "";

 
                }
            }
        }
        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Product';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Product")
                return;

            connection.Execute("Create Table Product (" +
                "Name VARCHAR(100) NOT NULL," +
                "Description VARCHAR(1000) NULL);");
        }
    }
}
