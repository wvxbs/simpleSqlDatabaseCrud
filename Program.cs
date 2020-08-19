using System;
using simpleSqlDatabaseCrud.src.connection;

namespace simpleSqlDatabaseCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadConfigFIleInfo loadConfigFIleInfo = new LoadConfigFIleInfo();
            ConnectToDatabase connectToDatabase = new ConnectToDatabase(loadConfigFIleInfo.GetConnectionString());

            
        }
    }
}
