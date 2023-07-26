using System;
using System.Xml.Linq;
using System.Linq;
using System.IO;


namespace NeptuneTasks
{
    public class Program
    {
        public static Usuario usuarioLogado = null;

        public static void Main()
        {
            //Necessáio para carregar a persistência dos usuários.
            NUsuario.Abrir();
            NTarefa.Abrir();
            //
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n       Bem-vindo(a) ao NeptuneTasks!\n");
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


                                case 1: MenuTarefasL(); break;    
                                case 99: SairSistema(); break;
                                case 98: AtualizarConta(usuarioLogado); break;




                            }
                        }
                        else
                        {
                            operacao = MenuComum();
                            switch (operacao)
                            {

                                case 1: MenuTarefasP(); break;
                                case 3: MenuEquipes(); break;
                                case 99: SairSistema(); break;
                                case 98: AtualizarConta(usuarioLogado); break;

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
            //Necessário para salvar perisistências dos usuários.
            NUsuario.Salvar();
            NTarefa.Salvar();
            
        }

        public static int MenuVisitante()
        {
            //Primeiro menu do sistema.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********************************************");
            Console.WriteLine("|                 OPÇÕES                   |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  1. Criar conta                          |");
            Console.WriteLine("|  2. Fazer login                          |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  00. Sair                                |");
            Console.WriteLine("********************************************");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine()); ;
        }
        public static int MenuAdmin()
        {
            //Menu para usuário que são lideres.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********************************************");
            Console.WriteLine("|              MENU DO LÍDER               |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  Escolha a operação desejada:            |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|  1. Área de tarefas pessoais             |");
            Console.WriteLine("|  2. Área de tarefas da equipe            |");
            Console.WriteLine("|  3. Área de equipes                      |");
            Console.WriteLine("|  4. Área de projetos                     |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  98. Atualizar conta                     |");
            Console.WriteLine("|  99. Sair                                |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("********************************************");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine()); ;
        }
        public static void MenuTarefasL()
        {
            //Menu para usuários que ainda não são líderes.
            bool continuar = true;
            while (continuar)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("********************************************");
                Console.WriteLine("|         Quadro de tarefas pessoais       |");
                Console.WriteLine("********************************************");
                Console.WriteLine("|  Escolha a operação desejada:            |");
                Console.WriteLine("|                                          |");
                Console.WriteLine("|  1. Visualizar tarefas existentes        |");
                Console.WriteLine("|  2. Adicionar tarefa                     |");
                Console.WriteLine("|  3. Excluir tarefa                       |");
                Console.WriteLine("|  4. Voltar                               |");
                Console.WriteLine("********************************************");
                Console.Write("\nOpção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MostrarTarefasPessoais();
                        break;
                    case 2:
                        CriarTarefa();
                        break;
                    case 3:
                        ExcluirTarefa();

                        break;

                    case 4:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

        }
        public static void MenuEquipes()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("********************************************");
                Console.WriteLine("|            Quadro de equipes             |");
                Console.WriteLine("********************************************");
                Console.WriteLine("|  Escolha a operação desejada:            |");
                Console.WriteLine("|                                          |");
                Console.WriteLine("|  1. Visualizar equipes                   |");
                Console.WriteLine("|  2. Adicionar equipe                     |");
                Console.WriteLine("|  3. Excluir equipe                       |");
                Console.WriteLine("|  4. Voltar                               |");
                Console.WriteLine("********************************************");
                Console.Write("\nOpção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    /*case 1:
                        MostrarEquipes();
                        break;*/
                    /*case 2:
                        CriarEquipe();
                        break;*/
                    /*case 3:
                        ExcluirTarefa();

                        break;*/

                    case 4:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

        }

        public static int MenuComum()
        {
            //Menu para usuários que ainda não são líderes.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********************************************");
            Console.WriteLine("|              MENU INICIAL                |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  Escolha a operação desejada:            |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|  1. Área de tarefas pessoais             |");
            Console.WriteLine("|  2. Área de tarefas de trabalho          |");
            Console.WriteLine("|  5. Visualizar sua equipe                |");
            Console.WriteLine("|  5. Visualizar projeto da equipe         |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  98. Atualizar conta                     |");
            Console.WriteLine("|  99. Sair                                |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("********************************************");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine());
        }
        public static void MenuTarefasP()
        {
            //Menu para usuários que ainda não são líderes.
            bool continuar = true;
            while (continuar)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("********************************************");
                Console.WriteLine("|         Quadro de tarefas pessoais       |");
                Console.WriteLine("********************************************");
                Console.WriteLine("|  Escolha a operação desejada:            |");
                Console.WriteLine("|                                          |");
                Console.WriteLine("|  1. Visualizar tarefas existentes        |");
                Console.WriteLine("|  2. Adicionar tarefa                     |");
                Console.WriteLine("|  3. Excluir tarefa                       |");
                Console.WriteLine("|  4. Voltar                               |");
                Console.WriteLine("********************************************");
                Console.Write("\nOpção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MostrarTarefasPessoais();
                        break;
                    case 2:
                        CriarTarefa();
                        break;
                    case 3:
                        ExcluirTarefa();
                        
                        break;

                    case 4:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

        }

        


        public static void CriarConta()
        {
            //Método para criar uma conta, e manda os parâmentro para outra função que insere em um XML.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                                          ");
            Console.WriteLine("********************************************");
            Console.WriteLine("|        Criar conta no NeptuneTask        |");
            Console.WriteLine("********************************************");
            Console.WriteLine("| * Informe o nome de usuário desejado:    |");
            string nome;
            while (true)
            {
                nome = Console.ReadLine();
                Usuario user = new Usuario { Nome = nome };
                if (NUsuario.procuraNomeIgual(user) == false)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nome de usuário já existente no sistema, tente outro nome por favor:");
                    Console.WriteLine("                                          ");
                }
            }
            Console.WriteLine("| * Informe a senha:                       |");
            string senha = Console.ReadLine();
            Console.WriteLine("| * Informe se deseja ser líder: (S/N):    |");
            bool admin = obterOpcaoAdm();
            Console.WriteLine("********************************************");
            Usuario u = new Usuario { Nome = nome, Senha = senha, Admin = admin };
            NUsuario.Inserir(u);
            Console.WriteLine("                                          ");
            Console.WriteLine("Conta inserida com sucesso");
            Console.WriteLine("                                          ");
            NUsuario.Salvar();
        }


        public static bool obterOpcaoAdm()
        {
            //Obtem a resposta do usuário caso ele deseje ser líder. E manda para a função na qual 
            //E manda para a função na qual chama ela.
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
            Console.WriteLine("|                                          |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|           Atualização de conta           |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  1. Mudar nome                           |");
            Console.WriteLine("|  2. Mudar senha                          |");
            Console.WriteLine("|  2. Tornar-se líder                      |");
            Console.WriteLine("********************************************");
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
                {
                    Console.WriteLine("                                                                ");
                    Console.WriteLine("         Bem-vindo(a), líder " + usuarioLogado.Nome + ".        ");
                }
                else
                {
                    Console.WriteLine("                                                     ");
                    Console.WriteLine("        Bem-vindo(a), " + usuarioLogado.Nome + ".    ");
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Ops, algo deu errado.");
            }
        }

        public static void SairSistema()
        {
            //Sai do sistema.
            usuarioLogado = null;
        }




        //------------------------PARTE REFERENTE ÀS TAREFAS--------------------------//

        public static void CriarTarefa()
        {
            //Método para criar uma tarefa, e manda os parâmentro para outra função que insere em um XML.

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                                          ");
            Console.WriteLine("********************************************");
            Console.WriteLine("|         Criar tarefas pessoais           |");
            Console.WriteLine("********************************************");
            Console.WriteLine("                                          ");
            Console.WriteLine("| * Informe o título da tarefa:            |");
            string titulo = Console.ReadLine();
            Console.WriteLine("                                          ");
            Console.WriteLine("| * Informe a descrição:                   |");
            string descricao = Console.ReadLine();
            Console.WriteLine("                                          ");
            Console.WriteLine("| * Defina a prioridade entre as opções:   |");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| (1) Baixa                                |");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("| (2) Média                                |");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| (3) Alta                                 |");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string prioridade = Console.ReadLine();
            Console.WriteLine("                                          ");
            Console.WriteLine("********************************************");
            Tarefa task = new Tarefa { Titulo = titulo, Descricao = descricao, Prioridade = prioridade};
            NTarefa.Inserir(task,usuarioLogado.Id);
            Console.WriteLine("                                          ");
            Console.WriteLine("Tarefa inserida com sucesso!              ");
            Console.WriteLine("                                          ");
            NTarefa.Salvar();
            MenuTarefasP();
        }
        public static void MostrarTarefasPessoais()

        {
            List<Tarefa> tarefasUsuario = NTarefa.ListarTarefasUsuario(usuarioLogado); 

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********************************************");
            Console.WriteLine("|       Tarefas pessoais do usuário        |");
            Console.WriteLine("********************************************");

            // Percorre a lista de tarefas para encontrar as tarefas associadas ao usuário logado
            foreach (Tarefa tarefa in NTarefa.ListarTarefasUsuario(usuarioLogado))
            {
                
                    if (tarefa.Prioridade == "1"){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("********************************************");
                    Console.WriteLine($"               ID =   {tarefa.IdTarefa}               ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Título: {tarefa.Titulo}                     ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Descrição: {tarefa.Descricao}");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Prioridade: Não urgente                     ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine("********************************************");
                    Console.ResetColor();
                }
                if (tarefa.Prioridade == "2")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("********************************************");
                    Console.WriteLine($"                ID =  {tarefa.IdTarefa}               ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Título: {tarefa.Titulo}                     ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Descrição: {tarefa.Descricao}");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Prioridade: Atenção!                        ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine("********************************************");
                    Console.ResetColor();
                }
                
                if (tarefa.Prioridade == "3")
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("********************************************");
                    Console.WriteLine($"                ID = {tarefa.IdTarefa}               ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Título: {tarefa.Titulo}                     ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Descrição: {tarefa.Descricao}");
                    Console.WriteLine("                                             ");
                    Console.WriteLine($"Prioridade: Urgente!                        ");
                    Console.WriteLine("                                             ");
                    Console.WriteLine("********************************************");
                    Console.ResetColor();
                }
                
            }

            Console.WriteLine("                                            ");
            Console.WriteLine("********************************************");
            Console.WriteLine("    Deseja atualizar alguma tarefa? (S/N)   ");
           bool resp =  obterOpcaoBool();
            if(resp == true)
            {
                Console.WriteLine("Digite o id da tarefa a ser atualizada: ");
                int id = int.Parse(Console.ReadLine());
                AtualizarTarefa(id);
            }

            // Chame o método para exibir o menu comum após mostrar as tarefas
            MenuTarefasP();
        }
        public static bool obterOpcaoBool()
        {
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
        public static void AtualizarTarefa(int id)
        {
            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoArquivoXML = Path.Combine(diretorioBase, "tarefas.xml");

            XDocument xmlDoc = XDocument.Load(caminhoArquivoXML);

            XElement tarefaElement = xmlDoc.Descendants("Tarefa").FirstOrDefault(e => e.Element("IdTarefa").Value == id.ToString());

            if (tarefaElement != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("|                                          |");
                Console.WriteLine("********************************************");
                Console.WriteLine("|      Atualização de tarefas pessoais     |");
                Console.WriteLine("********************************************");
                Console.WriteLine("|  1. Alterar título                       |");
                Console.WriteLine("|  2. Alterar descrição                    |");
                Console.WriteLine("|  3. Alterar prioridade                   |");
                Console.WriteLine("********************************************");
                Console.Write("\nOpção: ");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("Digite o novo nome desejado:");
                        tarefaElement.Element("Titulo").Value = Console.ReadLine();
                        Console.WriteLine("Título alterado com sucesso.");
                        break;
                    case 2:
                        Console.WriteLine("Digite a nova descrição desejada: ");
                        tarefaElement.Element("Descricao").Value = Console.ReadLine();
                        Console.WriteLine("Descrição alterada com sucesso.");
                        break;
                    case 3:
                        Console.WriteLine("Digite a nova prioridade desejada: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" (1) Baixa");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" (2) Média");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("(3) Alta");
                        Console.ResetColor();
                        tarefaElement.Element("Prioridade").Value = Console.ReadLine();
                        Console.WriteLine("Prioridade alterada com sucesso.");
                        break;
                    default:
                        Console.WriteLine("Número inválido.");
                        break;
                }
                NTarefa.Salvar();
                xmlDoc.Save(caminhoArquivoXML);
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }
        public static void ExcluirTarefa()
        {
            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoArquivoXML = Path.Combine(diretorioBase, "tarefas.xml");

            XDocument xmlDoc = XDocument.Load(caminhoArquivoXML);
            Console.WriteLine("************************* Danger Zone *************************");
            Console.WriteLine("Digite o id que fica no cabeçalho da tarefa que deseja excluir:");
            int id = int.Parse(Console.ReadLine());

            XElement tarefaElement = xmlDoc.Descendants("Tarefa").FirstOrDefault(e => e.Element("IdTarefa").Value == id.ToString());

            if (tarefaElement != null)
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Deseja mesmo excluir a tarefa? (S/N)   ");
                Console.ResetColor();
                char resp = char.Parse(Console.ReadLine());

                if (resp == 'S')
                {
                    // Remove o elemento da tarefa do XML
                    tarefaElement.Remove();

                    xmlDoc.Save(caminhoArquivoXML);
                    NTarefa.Salvar();
                    Console.WriteLine("Tarefa excluída com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }

            // Chame o método para exibir o menu comum após excluir a tarefa
            MenuTarefasP();
        }

        /*public static void CriarEquipe(Usuario criador, List<Usuario> usuariosDisponiveis, string )
        {
            Console.WriteLine("***************************");
            Console.WriteLine("|   Criar nova Equipe     |");
            Console.WriteLine("***************************");

            // Coleta o nome da equipe do usuário
            Console.WriteLine("Digite o nome da equipe: ");
            string nomeEquipe = Console.ReadLine();

            // Coleta a descrição da equipe do usuário
            Console.WriteLine("Digite a descrição da equipe: ");
            string descricaoEquipe = Console.ReadLine();

            // Cria uma nova equipe e preenche os atributos com os valores informados pelo usuário
            Equipe novaEquipe = new Equipe
            {
                NomeEquipe = nomeEquipe,
                descricao = descricaoEquipe,
                admin = criador,
                Membros = new List<Usuario>() // Inicializa a lista de membros vazia para a nova equipe
            };

            // Adiciona o criador da equipe como membro
            novaEquipe.Membros.Add(criador);

            // Exibe os usuários disponíveis para adicionar à equipe
            Console.WriteLine("Usuários disponíveis para adicionar à equipe:");

            foreach (Usuario usuario in usuariosDisponiveis)
            {
                Console.WriteLine($"- {usuario.Nome}");
            }

            // Solicita ao usuário o nome do membro que deseja adicionar
            Console.WriteLine("Digite o nome do usuário que deseja adicionar à equipe: ");
            string nomeUsuario = Console.ReadLine();

            // Procura o usuário na lista de usuários disponíveis pelo nome
            Usuario membro = usuariosDisponiveis.FirstOrDefault(u => u.Nome.Equals(nomeUsuario, StringComparison.OrdinalIgnoreCase));

            if (membro != null)
            {
                // Verifica se o usuário já é um membro da equipe
                if (!novaEquipe.Membros.Contains(membro))
                {
                    // Adiciona o usuário como membro da equipe
                    novaEquipe.Membros.Add(membro);
                    Console.WriteLine($"{membro.Nome} adicionado à equipe {novaEquipe.NomeEquipe} com sucesso!");
                }
                else
                {
                    Console.WriteLine($"{membro.Nome} já é membro da equipe {novaEquipe.NomeEquipe}.");
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado. Verifique o nome e tente novamente.");
            }

            // Agora, você pode chamar o método Inserir do NEquipe para adicionar a nova equipe à lista de equipes
            NEquipe.Inserir(novaEquipe, criador, idProjeto);

            Console.WriteLine("Equipe criada com sucesso!");
        }*/


    }


}




/*Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("********************************************");
            Console.WriteLine("|              MENU INICIAL                |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  Escolha a operação desejada:            |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|  1. Área de tarefas pessoais             |");
            Console.WriteLine("|  2. Área de tarefas de trabalho          |");
            Console.WriteLine("|  5. Visualizar sua equipe                |");
            Console.WriteLine("|  5. Visualizar projeto da equipe         |");
            Console.WriteLine("********************************************");
            Console.WriteLine("|  98. Atualizar conta                     |");
            Console.WriteLine("|  99. Sair                                |");
            Console.WriteLine("|  00. Fechar                              |");
            Console.WriteLine("********************************************");
*/


/*Console.ForegroundColor = ConsoleColor.DarkGreen;
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
Console.Write("\nOpção: ");*/