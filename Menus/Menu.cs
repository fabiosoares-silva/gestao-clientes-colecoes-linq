using GestaoDeClientesColecoesLinq.Modelos;
using GestaoDeClientesColecoesLinq.Repositorios;

namespace GestaoDeClientesColecoesLinq.Menus;
public static class Menu
{
    private static CadastroRepositorio? _repositorio;
    
    public static void ExibirMenuPrincipal()
    {
        bool opcoesMenuPrincipal = true;

        while (opcoesMenuPrincipal)
        {
            Console.Clear();
            Console.WriteLine("=== Buscar por cliente ===");
            Console.WriteLine("\n");
            Console.WriteLine("1. Por nome");
            Console.WriteLine("2. Por telefone");
            Console.WriteLine("3. Por email");
            Console.WriteLine("0. Sair");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Digite o nome do cliente:");
                    string nomeDigitado = Console.ReadLine()!;                    
                    var nomeBuscado = _repositorio!.BuscarPorNome(nomeDigitado);
                    Menu.ExibirResultadoNome(nomeBuscado);
                     
                    Console.ReadKey();
                    break;
                case "2":
                    // TODO: normalizar formato do telefone antes de comparar
                    // melhoria futura: aceitar qualquer formato usando IsDigit ou Regex
                    Console.WriteLine("Digite o telefone: Exemplo (11) 99999-9999");
                    string telefoneDigitado = Console.ReadLine()!;
                    var telefoneBuscado = _repositorio!.BuscarPorTelefone(telefoneDigitado);
                    Menu.ExbirResultadotelefone(telefoneBuscado);

                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Digite o email:");
                    string emailDigitado = Console.ReadLine()!;                    
                    var emailBuscado = _repositorio!.BuscarPorEmail(emailDigitado);
                    Menu.ExbirResultadoEmail(emailBuscado);

                    Console.ReadKey();
                    break;
                case "0":
                    opcoesMenuPrincipal = false;
                    Finalizar();
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
    private static void Finalizar()
    {
        Console.Clear();
        Console.WriteLine("Finalizando aplicação...");
        Thread.Sleep(2000);
        Console.Clear();
    }
    private static void ExibirResultadoNome(IEnumerable<Cliente> nomeBuscado)
    {
        var lista = nomeBuscado.ToList();

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

    private static void ExbirResultadotelefone(IEnumerable<Cliente> telefoneBuscado)
    {
        var lista = telefoneBuscado.ToList();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum telefone encontrado ou formato digitado não é válido.");
            return;
        }
        var quantidadeEncontrada = lista.Count;
        var textoResultado = quantidadeEncontrada > 1 ? "resultados" : "resultado";

        Console.WriteLine($"Resultado da busca: {quantidadeEncontrada} {textoResultado}.");

        foreach (var cliente in lista)
        {
            Console.WriteLine($"- {cliente.Telefone}, {cliente.Nome}");
        }
    }
    private static void ExbirResultadoEmail(IEnumerable<Cliente> emailBuscado)
    {
        var lista = emailBuscado.ToList();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum email encontrado ou formato digitado não é válido.");
            return;
        }
        var quantidadeEncontrada = lista.Count;
        var textoResultado = quantidadeEncontrada > 1 ? "resultados" : "resultado";

        Console.WriteLine($"Resultado da busca: {quantidadeEncontrada} {textoResultado}.");

        foreach (var cliente in lista)
        {
            Console.WriteLine($"- {cliente.Email}, {cliente.Nome}");
        }
    }
}
