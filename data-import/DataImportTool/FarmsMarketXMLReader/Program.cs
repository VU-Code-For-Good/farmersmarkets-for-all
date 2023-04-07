
using FarmsMarketXMLReader;

Console.WriteLine("starting");

var reader = new CSVMarketReader("dat/SNAP.csv");
var records = reader.ReadMarkets();

Console.Write("Enter your sqlite path: ");
var sqliteFilePath = Console.ReadLine();

var writer = new MarketSQLWriter(sqliteFilePath);

foreach (var record in records)
{
    writer.WriteToSQL(record);
}

Console.WriteLine("Done");
