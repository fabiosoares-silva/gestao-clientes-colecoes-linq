using GestaoDeClientesColecoesLinq.Repositorios;

using var arquivo = new FileStream("clientes.csv", FileMode.Open, FileAccess.Read);
using var stream = new StreamReader(arquivo);

var clientes = CadastroRepositorio.BuscarClientes(stream);
CadastroRepositorio.ExibirClientes(clientes);

