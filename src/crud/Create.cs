using System;
using System.Data.SqlClient;
using System.Text;

namespace simpleSqlDatabaseCrud.src.crud
{
    class Create
    {

        public string TableName { get; set; }

        string ConnectionString;


        string QueryString;
        string Rg; 
        string Nome;
        string Datanascimento;
        string Cpf;
        string Nomemae;
        string Profissao;

        public Create(string _ConnectionString)
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

            Query.Append($"INSERT INTO [dbo].[Pessoa] (RG,NOME,DATANASCIMENTO,CPF,NOMEMAE,PROFISSAO) ");
            Query.Append($"VALUES ('{Rg}','{Nome}','{Datanascimento}','{Cpf}','{Nomemae}','{Profissao}')");

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
