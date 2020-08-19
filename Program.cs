using System;
using simpleSqlDatabaseCrud.src.connection;
using simpleSqlDatabaseCrud.src.crud;

namespace simpleSqlDatabaseCrud
{
    class Program
    {
        static LoadConfigFIleInfo loadConfigFIleInfo = new LoadConfigFIleInfo();
        static string ConnectionString = loadConfigFIleInfo.GetConnectionString();
        static ConnectToDatabase Connect = new ConnectToDatabase(ConnectionString);
        static bool Run = true;

        static void Main(string[] args)
        {
            while(Run)
            ChooseQuestion();

            //Read read = new Read(ConnectionString);
        }

        static void ChooseQuestion()
        {
            int Select = 0;

            Console.WriteLine("1 para Inserir valor\n2 para Obter todos os valores\n3 para Atualizar um valor específico\n4 para Remover um valor específico\n\n0 para sair");
            if (int.TryParse(Console.ReadLine(), out Select))
            {
                switch (Select)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 0:
                        Run = false;
                        break;
                }
            }
        }

        static void Create()
        {    
            string Rg; 
            string Nome;
            string Datanascimento;
            string Cpf;
            string Nomemae;
            string Profissao;

            Console.WriteLine("Inserir Rg");
            Rg = Console.ReadLine();
            Console.WriteLine("Inserir Nome");
            Nome = Console.ReadLine();
            Console.WriteLine("Inserir Data de nascimento");
            Datanascimento = Console.ReadLine();
            Console.WriteLine("Inserir Cpf");
            Cpf = Console.ReadLine();
            Console.WriteLine("Inserir Nome da mãe");
            Nomemae = Console.ReadLine();
            Console.WriteLine("Inserir Profissão");
            Profissao = Console.ReadLine();

            Create create = new Create(ConnectionString);
            create.ProcessUserInput(Rg,Nome,Datanascimento,Cpf,Nomemae,Profissao);
            create.ExecuteQuery();
        }

        static void Read()
        {
            Read read = new Read(ConnectionString);
          
            read.ExecuteQuery();

            foreach(var i in read.GetPessoas())
            {
                Console.WriteLine($"\nRg: {i.Rg}\nNome: {i.Nome}\nData de nascimento: {i.DataNascimento}\nCPF: {i.Cpf}\nNome da mãe: {i.NomeMae}\nProfissão: {i.Profissao}\n");
            }

            Console.ReadLine();
        }

        static void Update()
        {    
            string Rg; 
            string Nome;
            string Datanascimento;
            string Cpf;
            string Nomemae;
            string Profissao;

            Console.WriteLine("Inserir Rg");
            Rg = Console.ReadLine();
            Console.WriteLine("Inserir Nome");
            Nome = Console.ReadLine();
            Console.WriteLine("Inserir Data de nascimento");
            Datanascimento = Console.ReadLine();
            Console.WriteLine("Inserir Cpf");
            Cpf = Console.ReadLine();
            Console.WriteLine("Inserir Nome da mãe");
            Nomemae = Console.ReadLine();
            Console.WriteLine("Inserir Profissão");
            Profissao = Console.ReadLine();

            Update update = new Update(ConnectionString);
            update.ProcessUserInput(Rg,Nome,Datanascimento,Cpf,Nomemae,Profissao);
            update.ExecuteQuery();
        }

        static void Delete()
        {
            string Rg; 

            Console.WriteLine("Inserir Rg");
            Rg = Console.ReadLine();

            Delete delete = new Delete(ConnectionString);
            delete.ProcessUserInput(Rg);
            delete.ExecuteQuery();
        }
    }
}
