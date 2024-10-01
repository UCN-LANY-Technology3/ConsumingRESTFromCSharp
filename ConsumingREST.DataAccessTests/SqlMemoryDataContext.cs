using ConsumingREST.DataAccess;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingREST.DataAccessTests
{
    internal class SqlMemoryDataContext : IDataContext<IDbConnection>
    {
        private readonly string _connectionString = "Data Source=:memory:";
        private SqliteConnection _connection; 

        public static IDataContext<IDbConnection> Instance => new SqlMemoryDataContext();

        public IDbConnection Open()
        {
            _connection = new(_connectionString);
            _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText =
            @"
                    CREATE TABLE Cities (
                        Zip TEXT NOT NULL,
                        Name TEXT NOT NULL
                    );

                    INSERT INTO Cities
                    VALUES ('9000', 'Aalborg'),
                           ('9220', 'Aalborg Ø'),
                           ('9210', 'Aalborg SØ');
                ";
            command.ExecuteNonQuery();

            return _connection;
        }
    }
}
