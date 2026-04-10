# Gestão de Clientes — Coleções e LINQ

Sistema console em C# com .NET 8 para gestão de clientes com persistência em CSV, desenvolvido como projeto prático de estudo da formação .NET Backend da Alura.

## Sobre o projeto

Aplicação console que simula um sistema de cadastro de clientes, permitindo buscar clientes por diferentes critérios a partir de um arquivo CSV com registros fictícios.

## Funcionalidades

- Busca de clientes por nome
- Busca de clientes por telefone
- Busca de clientes por e-mail
- Exibição de quantidade de resultados encontrados

## Tecnologias

- C# / .NET 8
- Manipulação de arquivos: leitura de CSV com `FileStream` e `StreamReader`
- Coleções: `IEnumerable<T>`, `yield return` para leitura lazy de dados
- LINQ: operações de filtro com delegates e expressões lambda
- Separação de responsabilidades: estrutura organizada em Modelos, Repositórios e Menus

## Estrutura do projeto

```
GestaoDeClientesColecoesLinq/
│   Program.cs
│   clientes.csv
│
├── Modelos/
│       Cliente.cs
│
├── Repositorios/
│       CadastroRepositorio.cs
│
└── Menus/
        Menu.cs
```

## Como executar

```bash
# Clone o repositório
git clone https://github.com/fabiosoares-silva/gestao-clientes-colecoes-linq.git

# Entre na pasta do projeto
cd gestao-clientes-colecoes-linq

# Execute
dotnet run
```

## Exemplo de saída

```
=== Gestão de Clientes ===

1. Buscar cliente
0. Sair

=== Buscar cliente ===

1. Por nome
2. Por telefone
3. Por email
4. voltar

Digite o nome do cliente:
Ana

Resultado da busca: 3 resultados.
- Ana Paula Ferreira
- Ana Silva Santos
- Ana Beatriz Rocha
```

## Débitos técnicos

- Busca por telefone requer formato exato: `(XX) XXXXX-XXXX`
  - Melhoria planejada: normalização com Regex para aceitar qualquer formato

## Próximos passos

- Normalizar busca por telefone com expressões regulares
- Migração da persistência para SQLite
- Interface gráfica com Windows Forms