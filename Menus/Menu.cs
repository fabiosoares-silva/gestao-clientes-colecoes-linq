using GestaoDeClientesColecoesLinq.Modelos;
using GestaoDeClientesColecoesLinq.Repositorios;

namespace GestaoDeClientesColecoesLinq.Menus;

public static class Menu
{
    private static CadastroRepositorio? _repositorio;

    public static void ExibirMenuPrincipal()
    {
        bool exibirMenuPrincipal = true;

        while (exibirMenuPrincipal)
        {
            Console.Clear();
            Console.WriteLine("=== Gestão de Clientes ===");
            Console.WriteLine("\n");
            Console.WriteLine("1. Buscar cliente");
            Console.WriteLine("2. Cadastrar cliente");
            Console.WriteLine("0. Sair");

            switch (Console.ReadLine())
            {
                case "1":
                    ExibirSubMenu();
                    break;
                case "2":
                    CadastrarCliente();
                    //TODO: implementar CadastrarCliente()
                    break;
                case "0":
                    exibirMenuPrincipal = false;
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        }
    }
    public static void ExibirSubMenu()
    {
        bool continuarNoSubmenu = true;

        while (continuarNoSubmenu)
        {
            Console.Clear();
            Console.WriteLine("=== Buscar por cliente ===");
            Console.WriteLine("\n");
            Console.WriteLine("1. Por nome");
            Console.WriteLine("2. Por telefone");
            Console.WriteLine("3. Por email");
            Console.WriteLine("4. voltar");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Digite o nome do cliente:");
                    string nomeDigitado = Console.ReadLine()!;
                    if (_repositorio == null) return;                    
                    var resultado =_repositorio.BuscarPorNome(nomeDigitado);
                    Menu.ExbirResultado(resultado);
                     
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Digite o telefone:");
                    string telefoneDigitado = Console.ReadLine()!;
                    //TODO: implementar BuscaPorTelefone
                    break;
                case "3":
                    Console.WriteLine("Digite o email:");
                    string emailDigitado = Console.ReadLine()!;
                    //TODO: implementar BuscaPorEmail
                    break;
                case "4":
                    continuarNoSubmenu = false;
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        }        
    }

    public static void Iniciar(CadastroRepositorio repositorio)
    {
        _repositorio = repositorio;
        ExibirMenuPrincipal();
    }

    public static void ExbirResultado(IEnumerable<Cliente> resultado)
    {
        var lista = resultado.ToList();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum cliente encontrado.");
            return;
        }
        var quantidadeEncontrada = lista.Count;
        var textoResultado = quantidadeEncontrada > 1 ? "resultados" : "resultado";

        Console.WriteLine($"Resultado da busca: {quantidadeEncontrada} {textoResultado}.");   
        
        foreach (var cliente in lista)
        {
            Console.WriteLine($"- {cliente.Nome}");
        }        
    }
    public static void CadastrarCliente()
    {
        Console.WriteLine("informe o nome do cliente:");
        string nomeInformado = Console.ReadLine()!;
        Console.WriteLine("Informe o telefone:");
        string telefoneInformado = Console.ReadLine()!;
        Console.WriteLine("Informe o email:");
        string emailInformado = Console.ReadLine()!;

    }
}
