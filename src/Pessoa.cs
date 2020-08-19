using System;
using System.Data.SqlClient;

namespace simpleSqlDatabaseCrud.src
{
    public class Pessoa
    {
        public string Rg { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string NomeMae { get; set; }
        public string Profissao { get; set; }
    }
}
