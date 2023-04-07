using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
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
        }

        public void WriteToSQL(FarmersMarketRecord record)
        {
            string insertSql = "INSERT INTO FarmersMarket (isSnapFriendly, name) VALUES (@isSnapFriendly, @name)";

            using (SqliteConnection connection = new SqliteConnection(_sqlitePath))
            {
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                connection.Execute(insertSql, new FarmersMarket()
                {
                    isSnapFriendly = true,
                    name = record.StoreName
                });
            }
        }
    }
}
