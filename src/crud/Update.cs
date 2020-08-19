using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace simpleSqlDatabaseCrud.src.crud
{
    class Update
    {
        string ConnectionString;
        
        string QueryString;
        string Rg; 
        string Nome;
        string Datanascimento;
        string Cpf;
        string Nomemae;
        string Profissao;

        public Update(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        public void ProcessUserInput(string rg, string nome, string datanascimento, string cpf, string nomemae, string profissao)
        {
            Rg = rg;
            Nome = nome;
            Datanascimento = datanascimento;
            Cpf = cpf;
            Nomemae = nomemae;
            Profissao = profissao;
        }

        private void CreateQueryString()
        {
            StringBuilder Query = new StringBuilder();

            Query.Append($"UPDATE [dbo].[Pessoa]");
            Query.Append($"Set NOME = '{Nome}', DATANASCIMENTO = '{Datanascimento}', CPF= '{Cpf}', NOMEMAE = '{Nomemae}', PROFISSAO = '{Profissao}'");
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
