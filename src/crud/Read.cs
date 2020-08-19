using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace simpleSqlDatabaseCrud.src.crud
{
    public class Read
    {

        private List<Pessoa> PessoaList = new List<Pessoa>();
        private string ConnectionString = "";
        private string QueryString = "";

        public Read(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;

            CreateQueryString();
            //ExecuteQuery();
        }

        private void CreateQueryString()
        {
            StringBuilder Query = new StringBuilder();

            Query.Append($"SELECT [RG],[NOME],[DATANASCIMENTO],[CPF],[NOMEMAE],[PROFISSAO]");
            Query.Append($"FROM [dbo].[Pessoa]");

            QueryString = Query.ToString();
        }

        /*(public void ExecuteQuery()
        {
            using(SqlConnection Connection = new SqlConnection(ConnectionString)) 
            {
                Connection.Open();

                using (SqlCommand command = new SqlCommand(QueryString, Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        foreach (var item in reader)
                        {
                            PessoaList.Add(item);
                        }
                    }
                }  
            }
        }*/

        public List<Pessoa> GetPessoas()
        {
            return PessoaList;
        }
        
    }
}
