using System;
using System.Xml.Linq;

namespace NeptuneTasks
{
    public class Program
    {
        public static Usuario usuarioLogado = null;

        public static void Main()
        {
            //Necessáio para carregar a persistência dos usuários.
            NUsuario.Abrir();
            //
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nBem-vindo(a) ao NeptuneTasks!\n");
            int operacao = 100;
            //Loop para sempre escutar e realizar as chamadas demandadas.
            while (operacao != 0)
            {
                try
                {
                    if (usuarioLogado == null)
                    {
                        operacao = MenuVisitante();
                        switch (operacao)
                        {
                            case 1: CriarConta(); break;
                            case 2: EntrarSistema(); break;
                        }
                    }
                    else
                    {
                        if (usuarioLogado.Admin == true)
                        {
                            operacao = MenuAdmin();
                            switch (operacao)
                            {

                                

                                case 99: SairSistema(); break;
                                case 98: AtualizarConta(usuarioLogado); break;


                                
                                
                            }
                        }
                        else
                        {
                            operacao = MenuComum();
                            switch (operacao)
                            {
                               
                                
                                case 99: SairSistema(); break;
                                case 98:AtualizarConta(usuarioLogado); break;
                                
                            }
                        }
                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine(erro.Message);
                }
            }
            Console.WriteLine("Encerramos por aqui, até logo!");
            //Necessário para salvar perisistências do usuários.
            NUsuario.Salvar();
            //
        }
        
        public static int MenuVisitante()
        {
            //Primeiro menu do sistema.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------- Opções --------");
            Console.WriteLine("| 01 - Criar conta       |");
            Console.WriteLine("| 02 - Entrar no Sistema |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("| 00 - Fim               |");
            Console.WriteLine("--------------------------");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine());
        }
        public static int MenuAdmin()
        {
            //Menu para usuário que são lideres.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------- Tarefas --------");
            Console.WriteLine("| 01 - Listar            |");
            Console.WriteLine("| 02 - Inserir           |");
            Console.WriteLine("| 03 - Atualizar         |");
            Console.WriteLine("| 04 - Excluir           |");
            Console.WriteLine("|                        |");
            Console.WriteLine("-------- Produtos --------");
            Console.WriteLine("| 05 - Listar            |");
            Console.WriteLine("| 06 - Inserir           |");
            Console.WriteLine("| 07 - Atualizar         |");
            Console.WriteLine("| 08 - Excluir           |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("| 98 - Atualizar conta   |");
            Console.WriteLine("| 99 - Sair              |");
            Console.WriteLine("| 00 - Fim               |");
            Console.WriteLine("--------------------------");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine());
        }
        public static int MenuComum()
        {
            //Menu para usuários que ainda não são líderes.

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------ Tarefas pessoais ------");
            Console.WriteLine("| 01 - Listar                |");
            Console.WriteLine("| 02 - Inserir               |");
            Console.WriteLine("| 03 - Atualizar             |");
            Console.WriteLine("| 04 - Excluir               |");
            Console.WriteLine("|                            |");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------ Área de trabalho ------");
            Console.WriteLine("| 05 - Tarefas de trabalho   |");
            Console.WriteLine("| 06 - Descrição da equipe   |");
            Console.WriteLine("| 07 - Descrição do projeto  |");
            Console.WriteLine("| 08 - Excluir               |");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("| 98 - Atualizar conta       |");
            Console.WriteLine("| 99 - Sair                  |");
            Console.WriteLine("| 00 - Fechar                |");
            Console.WriteLine("------------------------------");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine());
        }


        
        public static void CriarConta()
        {
            //Método para criar uma conta, e manda os parâmentro para outra função que insere em um XML.

            Console.WriteLine("Nova conta no sistema");
            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a senha: ");
            string senha = Console.ReadLine();
            Console.Write("Informe a se deseja ser administrador: ");
            bool admin = obterOpcaoAdm();
            Usuario u = new Usuario { Nome = nome, Senha = senha, Admin = admin };
            NUsuario.Inserir(u);
            Console.WriteLine("Conta inserida com sucesso");
            NUsuario.Salvar();
        }

    
        public static bool obterOpcaoAdm()
        {
            //Obtem a resposta do usuário caso ele deseje ser líder. E manda para a função na qual 
            //E manda para a função na qual chama ela.

            Console.WriteLine("Deseja ser um administrador?(S/N): ");
            string resposta = Console.ReadLine();

            if (resposta.ToUpper() == "S")
                return true;

            else if (resposta.ToUpper() == "N")
                return false;

            else
            {
                throw new Exception("Opção inválida. Digite apenas S ou N.");
            }
        }

        public static void ExcluirConta(Usuario c)
        { 
            //Função criada para excluir uma conta.

            Console.WriteLine("------- Danger Zone --------");
            Console.WriteLine("| 01 - Mudar nome          |");
            Console.WriteLine("| 02 - Trocar senha        |");
            Console.WriteLine("| 03 - Tornar-se líder     |");
            Console.WriteLine("| 00 - Voltar menu incial  |");
            Console.WriteLine("----------------------------");

        }

        public static void AtualizarConta(Usuario c)
        {
            //Função que atualiza os dados do usuário de acordo com o que ele deseja.
            //Mexe diretamente com o arquivo XML que esses dados estão persistidos.
            //Usa uma função que "universaliza" o caminho do arquivo para facilitar a mudança dos dados."

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--- Atualização da conta ---");
            Console.WriteLine("| 01 - Mudar nome          |");
            Console.WriteLine("| 02 - Trocar senha        |");
            Console.WriteLine("| 03 - Tornar-se líder     |");
            Console.WriteLine("| 00 - Voltar menu incial  |");
            Console.WriteLine("----------------------------");
            Console.Write("\nOpção: ");
            int op = int.Parse(Console.ReadLine());

            //Parte que eu disse que "universaliza" o caminho do arquivo.

            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoArquivoXML = Path.Combine(diretorioBase, "usuarios.xml");

            XDocument xmlDoc = XDocument.Load(caminhoArquivoXML);

     
            XElement usuarioElement = xmlDoc.Descendants("Usuario").FirstOrDefault(e => e.Element("Id").Value == c.Id.ToString());

            if (usuarioElement != null)
            {
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Seu nome antigo era: " + usuarioElement.Element("Nome").Value);
                        Console.WriteLine("Digite o novo nome desejado:");
                        usuarioElement.Element("Nome").Value = Console.ReadLine();
                        Console.WriteLine("Nome alterado com sucesso.");
                        break;
                    case 2:
                        Console.WriteLine("Sua antiga senha era: " + usuarioElement.Element("Senha").Value);
                        Console.WriteLine("Digite a nova senha desejada: ");
                        usuarioElement.Element("Senha").Value = Console.ReadLine();
                        Console.WriteLine("Senha alterada com sucesso.");
                        break;
                    case 3:
                        if (bool.Parse(usuarioElement.Element("Admin").Value) == false)
                        {
                            Console.WriteLine("Deseja realmente se tornar líder? (S/N)");
                            string resposta = Console.ReadLine();
                            if (resposta.ToUpper() == "S")
                            {
                                usuarioElement.Element("Admin").Value = true.ToString();
                                Console.WriteLine("Parabéns, agora você é um(a) líder.");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Número inválido.");
                        break;
                }

                xmlDoc.Save(caminhoArquivoXML);

                // Atualiza os dados do objeto Usuario passado como parâmetro
                c.Nome = usuarioElement.Element("Nome").Value;
                c.Senha = usuarioElement.Element("Senha").Value;
                c.Admin = bool.Parse(usuarioElement.Element("Admin").Value);
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
        public static void EntrarSistema()
        {
            //Faz o login do usuário no sistema e entrega o menu de acordo com seu perfil.
            try
            {
                Console.WriteLine("Entrar no sistema");
                Console.Write("Informe o nome: ");
                string nome = Console.ReadLine();
                Console.Write("Informe a senha: ");
                string senha = Console.ReadLine();
                usuarioLogado = NUsuario.EntrarSistema(nome, senha);
                if (usuarioLogado == null)
                    Console.WriteLine("Usuário ou senha incorretos");
                if (usuarioLogado.Admin == true)
                    Console.WriteLine("Bem-vindo(a), líder " + usuarioLogado.Nome + ".");
                else
                    Console.WriteLine("Bem-vindo(a), " + usuarioLogado.Nome + ".");
            } catch(Exception ex) 
            {
                Console.WriteLine("Ops, algo deu errado.");
            }
        }

        public static void SairSistema()
        {
            //Sai do sistema.
            usuarioLogado = null;
        }


    }
}