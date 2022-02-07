using System;

namespace DIO.Docummentario
{
    class Program
    {
        static DocumentarioRepositorio repositorio = new DocumentarioRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarDocumentario();
						break;
					case "2":
						InserirDocumentario();
						break;
					case "3":
                                                AtualizarDocumentario();
						break;
					case "4":
						ExcluirDocumentario();
						break;
					case "5":
						VisualizarDocumentario();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirDocumentario()
		{
			Console.Write("Digite o id do Documentário: ");
			int indiceDocumentario = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceDocumentario);
		}

        private static void VisualizarDocumentario()
		{
			Console.Write("Digite o id do Documentário: ");
			int indiceDocumentario = int.Parse(Console.ReadLine());

			var Documentario = repositorio.RetornaPorId(indiceDocumentario);

			Console.WriteLine(Documentario);
		}

        private static void AtualizarDocumentario()
		{
			Console.Write("Digite o id do Documentário: ");
			int indiceDocumentario = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Documentário: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Documentário: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Documentário: ");
			string entradaDescricao = Console.ReadLine();

			Documentario atualizaDocumentario = new Documentario(id: indiceDocumentario,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceDocumentario, atualizaDocumentario);
		}
        private static void ListarDocumentario()
		{
			Console.WriteLine("Listar Documentários");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Documentário cadastrado.");
				return;
			}

			foreach (var documentario in lista)
			{
                var excluido = Documentario.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Documentario.retornaId(), Documentario.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirDocumentario ()
		{
			Console.WriteLine("Inserir novo Documentário");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Documentário: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Documentário: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Documentário: ");
			string entradaDescricao = Console.ReadLine();

			Documentario novoDocumentario = new Documentário(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoDocumentario);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Documentários a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Documentário");
			Console.WriteLine("2- Inserir novo Documentário");
			Console.WriteLine("3- Atualizar Documentário");
			Console.WriteLine("4- Excluir Documentário");
			Console.WriteLine("5- Visualizar Documentário");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
