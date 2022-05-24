using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TestDBConnection
{
    class Program
    {
        public class User 
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            List<User> result = new List<User>();
            try
            {
                string ConnectionString = @"Server=10.93.9.117;Database=TestDB;User Id=leo666;Password=leo666;";
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var sql = "SELECT [ID], [AGE], [NAME] FROM [dbo].[USER]";
                    var tempResult = conn.Query(sql).ToList();
                    foreach (var item in tempResult)
                    {
                        User newUser = new User();
                        newUser.ID = item.ID;
                        newUser.Age = (int)item.AGE;
                        newUser.Name = item.NAME;
                    }
                }
            }
            catch (Exception ex)
            {
                //log here
            }
        }
    }
}
