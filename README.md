# Gestão de Clientes — Coleções e LINQ

Aplicação console em C# / .NET 8 para consulta e gerenciamento de dados a partir de arquivos CSV. Um projeto prático desenvolvido para exercitar lógica de programação e manipulação eficiente de coleções.

## Sobre o projeto

Aplicação console que simula um sistema de cadastro de clientes, permitindo buscar clientes por diferentes critérios a partir de um arquivo CSV com registros fictícios.

## Destaques do Projeto
- Busca Otimizada: Uso de LINQ e Yield Return para filtragem de dados com baixo consumo de memória.
- Interface Console: Menu interativo para busca por nome, telefone e e-mail.
- Boas Práticas: Código organizado com separação de responsabilidades e foco em legibilidade.

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
=== Buscar cliente ===

1. Por nome
2. Por telefone
3. Por email
0. Sair

Digite o nome do cliente:
Livia

Resultado da busca: 22 resultados.
- Livia Machado Costa | (92) 92591-1929 | livia.machado48@uol.com.br
- Livia Ferreira Mendes | (81) 96516-1567 | livia.ferreira461@uol.com.br
- Livia Nunes Vieira | (11) 91636-4082 | livia.nunes432@gmail.com
- Olivia Teixeira Castro | (89) 99080-4005 | olivia.teixeira789@hotmail.com
- Livia Cavalcanti Rocha | (41) 94433-7548 | livia.cavalcanti445@outlook.com
- Olivia Pereira Pereira | (91) 93897-2055 | olivia.pereira624@hotmail.com
- Livia Ramos Araujo | (96) 92193-6598 | livia.ramos711@gmail.com
- Olivia Araujo Lopes | (55) 94117-3534 | olivia.araujo766@outlook.com
- Olivia Andrade Martins | (13) 95260-3028 | olivia.andrade52@hotmail.com
- Olivia Rocha Santos | (22) 91544-2826 | olivia.rocha202@hotmail.com
- Livia Moraes Cardoso | (77) 97799-8560 | livia.moraes125@yahoo.com.br
- Livia Andrade Vieira | (88) 93520-1329 | livia.andrade387@hotmail.com
- Livia Marques Andrade | (64) 99584-3222 | livia.marques366@yahoo.com.br
- Livia Martins Martins | (83) 96770-7516 | livia.martins399@yahoo.com.br
- Olivia Marques Monteiro | (81) 97904-8182 | olivia.marques898@yahoo.com.br
- Olivia Carvalho Carvalho | (75) 93113-6565 | olivia.carvalho264@yahoo.com.br
- Livia Alves Machado | (65) 95907-8957 | livia.alves15@uol.com.br
- Olivia Andrade Mendes | (13) 91942-2120 | olivia.andrade385@uol.com.br
- Livia Machado Martins | (69) 93854-9012 | livia.machado203@uol.com.br
- Livia Ribeiro Ramos | (95) 92903-9652 | livia.ribeiro459@yahoo.com.br
- Livia Carvalho Lima | (51) 96680-1501 | livia.carvalho301@outlook.com
- Olivia Costa Nascimento | (85) 95653-8669 | olivia.costa738@outlook.com
```

## Débitos técnicos

- Busca por telefone requer formato exato: `(XX) XXXXX-XXXX`
  - Melhoria planejada: normalização com Regex para aceitar qualquer formato

## Próximos passos

- Normalizar busca por telefone com expressões regulares
- Migração da persistência para SQLite
- Interface gráfica com Windows Forms