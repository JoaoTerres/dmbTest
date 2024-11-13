# dmbTest

- **Backend**: ASP.NET Core Web API com MVC (Model-View-Controller).
- **ORM**: Entity Framework Core com Repository Pattern para acesso ao banco de dados.
- **Validação**: FluentValidation para validação de dados.
- **Banco de Dados**: Utilização do FluentMigrator para migrações de banco de dados.
- **Testes Unitários**: xUnit para cobertura de testes de unidades.
- **Interface de Apresentação**: Interface básica em MVC para interação com a Web API.

O sistema permite cadastrar, listar, atualizar e excluir produtos, além de garantir boas práticas de programação, como a implementação dos princípios de SOLID.

## Tecnologias Utilizadas

- **ASP.NET Core** (Web API)
- **Entity Framework Core**
- **FluentMigrator** para migrações de banco de dados
- **FluentValidation** para validação de entradas
- **xUnit** para testes unitários
- **Docker** para contêineres
- **SQL Server** como banco de dados

- Antes de começar, certifique-se de que o seguinte está instalado na sua máquina:

- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/)
- [.NET 8.0]([https://dotnet.microsoft.com/download/dotnet/6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0))
- [Docker](https://www.docker.com/products/docker-desktop)
- [Postgres](https://www.postgresql.org/download/)

1. **Clone o repositório**:
2. **Restaure as dependências do projeto**:
3. **Execute a aplicação localmente**:
4. **Ao executar o projeto as migrações seram geradas**

Isso criará e aplicará a tabela `Produtos` no banco de dados.

## Instruções para Rodar os Testes Unitários

O projeto usa o xUnit para testes unitários. Para rodar os testes, basta seguir os passos abaixo:

1. **Abra o terminal e navegue até a pasta do projeto de testes**.

2. **Execute os testes**:

