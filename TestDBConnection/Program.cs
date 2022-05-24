using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace TestDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = @"Server=1.1.1.1;Database=TestDB;User Id=leo666;Password=leo666;";
            using var conn = new SqlConnection(ConnectionString);
            var sql = "SELECT ID, TEXT, DESCRIPTION FROM SAMPLE";
            var results = conn.Query(sql).ToList();
            foreach (var item in results) 
            {

            }
        }
    }
}
