using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FarmsMarketXMLReader.DatabaseFolders;
using FarmsMarketXMLReader.Models;
using Microsoft.Data.Sqlite;

namespace FarmsMarketXMLReader
{
    public class MarketSQLWriter
    {
        private readonly string _sqlitePath;

        public MarketSQLWriter(string sqlitePath)
        {
            _sqlitePath = $"Data Source={sqlitePath}";
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
        }

        public void WriteToSQL(FarmersMarketRecord record)
        {
            string contactSQL = "INSERT INTO ContactInfo (address) VALUES (@Address); SELECT last_insert_rowid();";
            string farmersMarketSQL = "INSERT INTO FarmersMarket (isSnapFriendly, name,contact) VALUES (@isSnapFriendly, @name, @contactId); SELECT last_insert_rowid();";

            using (SqliteConnection connection = new SqliteConnection(_sqlitePath))
            {
                var contact = new ContactInfo()
                {
                    Address = $"{record.AddlAddress},{record.City}, {record.State}, {record.City}"
                };

                contact.Id = connection.QuerySingle<int>(contactSQL, contact);

                var market = new FarmersMarket()
                {
                    isSnapFriendly = true,
                    name = record.StoreName,
                    contact = contact
                };

                market.id = connection.QuerySingle<int>(farmersMarketSQL, market);
            }
        }
    }
}
