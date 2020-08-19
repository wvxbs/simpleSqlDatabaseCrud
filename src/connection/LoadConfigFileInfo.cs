using System;
using System.Configuration;

namespace simpleSqlDatabaseCrud.src.connection
{
    public class LoadConfigFIleInfo
    {
        public string GetConnectionString()
        {
              try
             {                 
                 return ConfigurationManager.AppSettings["ConnectionString"];
             }
             catch
             {
              throw;
             }
        }
}}