using GestaoDeClientesColecoesLinq.Modelos;
using System.Text.RegularExpressions;

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
            var telefone = "Telefone não encontrado";
            var match = Regex.Match(linha, @"\((\d{2})\) (\d{5})-(\d{4})");   
            if(match.Success)
            {
                var DDD = match.Groups[1].Value;
                var prefixoTelefone = match.Groups[2].Value;
                var sufixoTelefone = match.Groups[3].Value;

                telefone = $"{DDD} {prefixoTelefone}{sufixoTelefone}";
            }

            var cliente = new Cliente
            {
                Id = int.Parse(partes[0]),
                Nome = string.IsNullOrWhiteSpace(partes[1]) ? "Nome não encontrado" : partes[1],
                Telefone = telefone,
                Email = string.IsNullOrWhiteSpace(partes[3]) ? "Email não encontrado" : partes[3]
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
    public IEnumerable<Cliente> BuscarPorTelefone(string respostaUsuario)
    {
        return Buscar(c => c.Telefone == respostaUsuario);
    }
    public IEnumerable<Cliente> BuscarPorEmail(string respostaUsuario)
    {
        return Buscar(c => c.Email == respostaUsuario);
    }
}
