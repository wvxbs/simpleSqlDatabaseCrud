using System;
using System.Configuration;
using System.Data.SqlClient;

namespace simpleSqlDatabaseCrud.src.connection
{
    public class ConnectToDatabase
    {
    private bool Passed = false;
    private SqlConnection Connection;

        public ConnectToDatabase(string ConnectionString)
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString)) 
            {
                try
                {
                    Connection = conn;
                    Passed = true;
                }
                catch
                {
                    throw;
                }
            }
        }

        public SqlConnection GetConnection()
        {
            return Connection;
        }

        public bool ConnectToDatabaseHasBeenStablished()
        {
            return Passed;
        }
    }
}