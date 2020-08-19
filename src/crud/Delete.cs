using System;
using System.Data.SqlClient;
using System.Text;

namespace simpleSqlDatabaseCrud.src.crud
{
    class Delete
    {
        string ConnectionString;

        string QueryString;
        string Rg; 

        public Delete(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        public void ProcessUserInput(string rg)
        {
            Rg = rg;
        }

        private void CreateQueryString()
        {
            StringBuilder Query = new StringBuilder();

            Query.Append($"DELETE FROM [dbo].[Pessoa]");
            Query.Append($"WHERE RG = '{Rg}'");

            QueryString = Query.ToString();
        }

        public void ExecuteQuery()
        {
            CreateQueryString();       

            using(SqlConnection Connection = new SqlConnection(ConnectionString)) 
            {
                Connection.Open();

                using (SqlCommand Command = Connection.CreateCommand())
                {
                    Command.CommandText = QueryString;
                    Command.ExecuteNonQuery();
                }  
            }
        } 
    }
}
