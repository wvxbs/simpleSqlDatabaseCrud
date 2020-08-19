using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
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
        }

        private void CreateQueryString()
        {
            StringBuilder Query = new StringBuilder();

            Query.Append($"SELECT [RG],[NOME],[DATANASCIMENTO],[CPF],[NOMEMAE],[PROFISSAO]");
            Query.Append($"FROM [dbo].[Pessoa]");

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
                    SqlDataReader reader = Command.ExecuteReader();
                    
                    while(reader.Read())
                    {
                        Pessoa pessoa = new Pessoa();
                        pessoa.Rg = reader["RG"].ToString();
                        pessoa.Nome = reader["NOME"].ToString();
                        pessoa.DataNascimento= reader["DATANASCIMENTO"].ToString();
                        pessoa.Cpf = reader["CPF"].ToString();
                        pessoa.NomeMae = reader["NOMEMAE"].ToString();
                        pessoa.Profissao = reader["PROFISSAO"].ToString();

                        PessoaList.Add(pessoa);
                    }
                }  
            }
        }

        public List<Pessoa> GetPessoas()
        {
            return PessoaList;
        }
        
    }
}
