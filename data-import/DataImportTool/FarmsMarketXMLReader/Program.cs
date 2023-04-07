
using FarmsMarketXMLReader;

Console.WriteLine("starting");

var reader = new CSVMarketReader("dat/SNAP.csv");
var records = reader.ReadMarkets();

Console.WriteLine("Done");
