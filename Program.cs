using System;

class Program
{
	public Usuario usuarioLogado = null;

	public static void Main()
	{
		NTarefa.Abrir();
		NUsuario.Abrir();
		Console.ForegroundColor = ConsoleColor.DarkCyan;
		Console.WriteLine("\nBem-vindo(a) ao NeptuneTasks!\n");
		int op = 100;
		while (op != 0)
		{
			try
			{
				if (usuarioLogado == null)
				{
					op = MenuVisitante();
					switch (op)
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
						}
					}
					else
					{
						operacao = MenuComum();
						switch (operacao)
						{
							case 1: // Alguma ação específica para usuários comuns
								break;
							case 99: SairSistema(); break;
						}
					}
				}
			}
			catch (Exception erro)
			{
				Console.WriteLine(erro.Message);
			}
		}
		Console.WriteLine("Bye!");
		NTarefas.Salvar();
		NUsuario.Salvar();
	}
	public static int MenuVisitante()
	{
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
		Console.ForegroundColor = ConsoleColor.DarkCyan;
		Console.WriteLine("------- Tarefas ------");
		Console.WriteLine("| 01 - Listar        |");
		Console.WriteLine("| 02 - Inserir       |");
		Console.WriteLine("| 03 - Atualizar     |");
		Console.WriteLine("| 04 - Excluir       |");
		Console.WriteLine("|                    |");
		Console.WriteLine("------ Produtos ------");
		Console.WriteLine("| 05 - Listar        |");
		Console.WriteLine("| 06 - Inserir       |");
		Console.WriteLine("| 07 - Atualizar     |");
		Console.WriteLine("| 08 - Excluir       |");
		Console.WriteLine("----------------------");
		Console.WriteLine("| 99 - Sair          |");
		Console.WriteLine("| 00 - Fim           |");
		Console.WriteLine("----------------------");
		Console.Write("\nOpção: ");
		return int.Parse(Console.ReadLine());
	}
	public static int MenuComum()
	{
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
		Console.WriteLine("| 99 - Sair                  |");
		Console.WriteLine("| 00 - Fechar                |");
		Console.WriteLine("------------------------------");
		Console.Write("\nOpção: ");
		return int.Parse(Console.ReadLine());
	}

	public static void CriarConta()
	{
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
	}

	public static bool obterOpcaoAdm()
	{
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

	public static void EntrarSistema()
	{
		Console.WriteLine("Entrar no sistema");
		Console.Write("Informe o nome: ");
		string nome = Console.ReadLine();
		Console.Write("Informe a senha: ");
		string senha = Console.ReadLine();
		usuarioLogado = NUsuario.EntrarSistema(nome, senha);
		if (usuarioLogado == null)
			Console.WriteLine("Usuário ou senha incorretos");
		else
			Console.WriteLine("Bem-vindo(a), " + usuarioLogado.Nome);
	}

	public static void SairSistema()
	{
		usuarioLogado = null;
	}

	public static void TarefaListar()
	{
		Console.WriteLine("Listagem de categorias");
		foreach (Categoria c in NCategoria.Listar())
			Console.WriteLine(c);
		Console.WriteLine();
	}
	public static void TarefaInserir()
	{
		Console.WriteLine("Inserção de tarefa");
		Console.Write("Informe a descrição: ");
		string s = Console.ReadLine();
		Categoria c = new Categoria { Descricao = s };
		NCategoria.Inserir(c);
		Console.WriteLine("Categoria inserida com sucesso");
	}
	public static void TarefaAtualizar()
	{
		CategoriaListar();
		Console.Write("Informe o id para atualizar: ");
		int id = int.Parse(Console.ReadLine());
		Console.Write("Informe a descrição: ");
		string s = Console.ReadLine();
		Categoria c = new Categoria { Id = id, Descricao = s };
		NCategoria.Atualizar(c);
		Console.WriteLine("Categoria atualizada com sucesso");
	}
	public static void TarefaExcluir()
	{
		CategoriaListar();
		Console.Write("Informe o id para excluir: ");
		int id = int.Parse(Console.ReadLine());
		Categoria c = new Categoria { Id = id };
		NCategoria.Excluir(c);
		Console.WriteLine("Categoria excluída com sucesso");
	}

	/*public static void ProdutoListar()
	{
		Console.WriteLine("Listagem de produtos");
		foreach (Produto p in NProduto.Listar())
		{
			Categoria c = NCategoria.Listar(p.IdCategoria);
			Console.WriteLine(p + " - " + c.Descricao);
		}
		Console.WriteLine();
	}
	public static void ProdutoInserir()
	{
		Console.WriteLine("Inserção de produtos");
		Console.Write("Informe a descrição: ");
		string s = Console.ReadLine();
		Console.Write("Informe o preço: ");
		double p = double.Parse(Console.ReadLine());
		Console.Write("Informe o estoque: ");
		int e = int.Parse(Console.ReadLine());
		CategoriaListar();
		Console.Write("Informe o id da categoria: ");
		int ic = int.Parse(Console.ReadLine());
		Produto prod = new Produto { Descricao = s, Preco = p, Estoque = e, IdCategoria = ic };
		NProduto.Inserir(prod);
		Console.WriteLine("Produto inserido com sucesso");
	}
	public static void ProdutoAtualizar()
	{
		ProdutoListar();
		Console.Write("Informe o id para atualizar: ");
		int id = int.Parse(Console.ReadLine());
		Console.Write("Informe a descrição: ");
		string s = Console.ReadLine();
		Console.Write("Informe o preço: ");
		double p = double.Parse(Console.ReadLine());
		Console.Write("Informe o estoque: ");
		int e = int.Parse(Console.ReadLine());
		CategoriaListar();
		Console.Write("Informe o id da categoria: ");
		int ic = int.Parse(Console.ReadLine());
		Produto prod = new Produto { Id = id, Descricao = s, Preco = p, Estoque = e, IdCategoria = ic };
		NProduto.Atualizar(prod);
		Console.WriteLine("Produto atualizado com sucesso");
	}
	public static void ProdutoExcluir()
	{
		ProdutoListar();
		Console.Write("Informe o id para excluir: ");
		int id = int.Parse(Console.ReadLine());
		Produto prod = new Produto { Id = id };
		NProduto.Excluir(prod);
		Console.WriteLine("Produto excluído com sucesso");


	    ( Para facilitar na hora de construir menu de equipes.")
		Console.WriteLine("------ Produtos ------");
		Console.WriteLine("| 05 - Listar        |");
		Console.WriteLine("| 06 - Inserir       |");
		Console.WriteLine("| 07 - Atualizar     |");
		Console.WriteLine("| 08 - Excluir       |");
	}*/
}