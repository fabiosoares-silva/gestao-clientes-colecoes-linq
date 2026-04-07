using GestaoDeClientesColecoesLinq.Modelos;

namespace GestaoDeClientesColecoesLinq.Repositorios;

public class CadastroRepositorio
{
    private readonly string _caminhoDoArquivo;

    public CadastroRepositorio(string caminho)
    {
        _caminhoDoArquivo = caminho;
    }
    public IEnumerable<Cliente> ObterDadosClientes()
    {
        using var arquivo = new FileStream(_caminhoDoArquivo, FileMode.Open, FileAccess.Read);
        using var stream = new StreamReader(arquivo);


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

    public IEnumerable<Cliente> Buscar(Func<Cliente, bool> condicao)
    {
        return ObterDadosClientes().Where(condicao);
    }
    public IEnumerable<Cliente> BuscarPorNome(string respostaUsuario)
    {
        return Buscar(c => c.Nome.Contains(respostaUsuario, StringComparison.OrdinalIgnoreCase));        
    }

}
