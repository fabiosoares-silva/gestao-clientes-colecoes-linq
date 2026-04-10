using GestaoDeClientesColecoesLinq.Menus;
using GestaoDeClientesColecoesLinq.Repositorios;

var repositorio = new CadastroRepositorio("clientes.csv");

Menu.Iniciar(repositorio); // 95524-7286