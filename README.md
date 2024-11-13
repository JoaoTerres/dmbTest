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
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0))
- [Docker](https://www.docker.com/products/docker-desktop)
- [Postgres](https://www.postgresql.org/download/)

1. **Clone o repositório**:
2. **Restaure as dependências do projeto**:
3. **Execute a aplicação localmente**:
4. **Ao executar o projeto as migrações serão geradas**

Isso criará e aplicará a tabela `Produtos` no banco de dados.

## Instruções para Rodar os Testes Unitários

O projeto usa o xUnit para testes unitários. Para rodar os testes, basta seguir os passos abaixo:

1. **Abra o terminal e navegue até a pasta do projeto de testes**.

2. **Execute os testes**:

# Estrutura do Projeto
Pasta Principal: dbm.Api
Connected Services: Serviços conectados para facilitar a integração com serviços externos.

Dependências: Bibliotecas e pacotes necessários para o projeto.

Properties: Propriedades e configurações do projeto.

Config: Contém extensões para a configuração dos serviços, como ServiceConfigExtensions.cs.

Context: Inclui o contexto do banco de dados com a classe AppDbContext.cs.

Controllers: Controladores da API, como ProductController.cs, que gerenciam as rotas e as ações relacionadas aos produtos.

DTO (Data Transfer Objects): Classes para transferência de dados entre camadas, como ProductDTO.cs.

Migrations: Armazena as migrações do Entity Framework, que gerenciam as alterações na estrutura do banco de dados, como CreatProductTable.cs.

Models: Classes de modelo que representam as entidades do domínio, como Product.cs.

Profiles: Perfis de mapeamento para o AutoMapper, como ProductProfile.cs, que define como mapear entre modelos e DTOs.

Repositories: Contém repositórios que encapsulam a lógica de acesso a dados. Inclui uma pasta para interfaces (Interfaces) e a implementação de repositórios, como ProductRepository.cs.

Services: Contém a lógica de negócios e interfaces para os serviços. Inclui ProductService.cs na pasta de implementação e interfaces na subpasta Interfaces.

Validations: Validações de dados, como ProductValidator.cs, para garantir a integridade dos dados.

Arquivos de Configuração
appsettings.json e appsettings.Development.json: Configurações da aplicação.

Dockerfile: Script para a construção da imagem Docker.

Program.cs: Ponto de entrada da aplicação.

Pasta de Testes: dbm.Test
Dependências: Bibliotecas e pacotes necessários para os testes.

Repositories: Testes dos repositórios, como ProductRepositoryTest.cs.

Services: Testes dos serviços, como ProductServiceTest.cs.

Validations: Testes das validações de dados, como ProductValidatorTest.cs.

Descrição das Camadas e Responsabilidades
Config: Contém extensões de configuração do serviço, ajudando na configuração inicial dos serviços.

Context: Inclui a classe AppDbContext, responsável pelo contexto do banco de dados, gerenciamento das conexões e mapeamento de entidades para tabelas do banco de dados.

Controllers: Define os controladores da API, como ProductController, que gerencia as rotas e as ações relacionadas aos produtos.

DTO (Data Transfer Object): Inclui classes para a transferência de dados entre camadas, como ProductDTO, que representa a estrutura de dados dos produtos.

Migrations: Armazena as migrações do Entity Framework, como CreatProductTable, que gerencia as alterações na estrutura do banco de dados.

Models: Contém as classes de modelo, como Product, que representam as entidades do domínio.

Profiles: Inclui perfis de mapeamento para o AutoMapper, como ProductProfile, que define como mapear entre modelos e DTOs.

Repositories: Define os repositórios, que encapsulam a lógica de acesso a dados, como ProductRepository.

Services: Contém a lógica de negócios, como ProductService, e interfaces para os serviços.

Validations: Inclui validações, como ProductValidator, que garantem a integridade dos dados.

Explicação sobre a Escolha de Tecnologias e Padrões de Projeto
ASP.NET Core: Para construção da API devido à sua performance e facilidade de uso.

Entity Framework Core: ORM utilizado para facilitar o acesso ao banco de dados.

AutoMapper: Simplifica o mapeamento de objetos entre diferentes camadas.

FluentValidation: Utilizado para validação de dados de maneira declarativa.

Os padrões de projeto como Repository Pattern e Dependency Injection foram escolhidos para promover a separação de preocupações, aumentando a manutenibilidade e testabilidade do código.

Desafios Encontrados Durante o Desenvolvimento e Como Foram Solucionados
Desafio 1: Integração de Configurações

Solução: Implementação de uma classe de extensões (ServiceConfigExtensions) para centralizar a configuração dos serviços.

Desafio 2: Mapeamento de Objetos

Solução: Utilização do AutoMapper para automatizar e simplificar o mapeamento entre modelos e DTOs.

Desafio 3: Validação de Dados

Solução: Implementação de validações utilizando FluentValidation para garantir a consistência e integridade dos dados.

Plano de Testes
Os testes unitários cobrem os seguintes cenários:

Repositories: Testes para garantir que o acesso aos dados está funcionando conforme esperado (ProductRepositoryTest).

Services: Testes da lógica de negócios para assegurar o comportamento correto dos serviços (ProductServiceTest).

Validations: Testes das validações para verificar que os dados estão sendo validados corretamente (ProductValidatorTest).

Os testes foram escritos utilizando ferramentas de teste como xUnit para garantir que a qualidade do código é mantida

