using GestaoDeClientesColecoesLinq.Modelos;

namespace GestaoDeClientesColecoesLinq.Repositorios;

public class CadastroRepositorio 
{
    public static IEnumerable<Cliente> BuscarClientes(StreamReader stream)
    {

        var linha = stream.ReadLine();

        while (linha is not null)
        {
            var partes = linha.Split(';');
            var cliente = new Cliente
            {
                Id = int.Parse(partes[0]),
                Nome = partes[1],
                Telefone = partes[2],
                Email = partes[3]
            };
            yield return cliente;
            linha = stream.ReadLine();
        }
    }

    public static void ExibirClientes(IEnumerable<Cliente> clientes)
    {
        var contador = 1;
        Console.WriteLine("\nClientes:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($" - {cliente.Nome}");
            contador++;
            if (contador > 30) break;
        }
    }
}
