# 📌 TarefasApi

API REST desenvolvida em **.NET 9** com foco na consolidação de
fundamentos de backend.

Mais do que um CRUD, este projeto foi construído para aprofundar
conceitos essenciais como:

-   Arquitetura em camadas (Controller, Service, Repository)
-   Entity Framework Core e ciclo de vida do DbContext
-   Middleware para logging e tratamento global de exceções
-   Testes de integração com WebApplicationFactory
-   Uso de EF Core InMemory para isolamento de banco em testes
-   Uso correto de async/await

------------------------------------------------------------------------

## 🚀 Tecnologias Utilizadas

-   .NET 9
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQL Server
-   EF Core InMemory (para testes)
-   AutoMapper
-   xUnit (testes)
-   WebApplicationFactory

------------------------------------------------------------------------

## 🏗 Arquitetura

O projeto segue o padrão de separação por responsabilidades:

### 📂 Controllers

Responsáveis por receber as requisições HTTP e retornar respostas
adequadas.

### 📂 Services

Camada de regras de negócio e orquestração da aplicação.

### 📂 Repositories

Responsável pelo acesso aos dados via Entity Framework.

### 📂 Data

Contém o DbContext e configurações do EF Core.

### 📂 Middlewares

Implementações para: - Logging de requisições - Tratamento global de
exceções

------------------------------------------------------------------------

## 🔄 Fluxo de Requisição

1.  A requisição passa pelos Middlewares
2.  O Controller recebe a requisição
3.  O Service executa a regra de negócio
4.  O Repository acessa o banco via EF Core
5.  A resposta retorna passando novamente pelos Middlewares

------------------------------------------------------------------------

## 🗄 Banco de Dados

### Produção / Desenvolvimento

Utiliza **SQL Server** configurado via connection string.

### Testes

Utiliza **EF Core InMemory Database** para:

-   Evitar poluir o banco real
-   Tornar os testes independentes
-   Melhorar velocidade de execução

------------------------------------------------------------------------

## 🧪 Testes

A aplicação possui **testes de integração** que validam:

-   Pipeline completo da aplicação
-   Middlewares
-   Controllers
-   Services
-   Repositórios
-   Integração com EF Core

Tecnologias utilizadas:

-   xUnit
-   WebApplicationFactory
-   EF Core InMemory

Estrutura padrão de testes:

-   Arrange
-   Act
-   Assert

------------------------------------------------------------------------

## 📌 Endpoints Principais

### Criar tarefa

POST /api/Tarefa

### Listar tarefas

GET /api/Tarefa

### Buscar por ID

GET /api/Tarefa/{id}

### Atualizar tarefa

PUT /api/Tarefa/{id}

### Deletar tarefa

DELETE /api/Tarefa/{id}

------------------------------------------------------------------------

## 🛠 Como Executar

``` bash
git clone <https://github.com/Lmatias122/TarefasApi.git>
cd TarefasApi
dotnet restore
dotnet run
```

A API estará disponível em:

https://localhost:xxxx

------------------------------------------------------------------------

## 📈 Melhorias Futuras

-   Implementar autenticação e autorização
-   Adicionar mensageria (RabbitMQ ou similar)
-   Implementar logs estruturados
-   Adicionar validações mais robustas
-   Implementar paginação e filtros avançados

------------------------------------------------------------------------

## 🎯 Objetivo do Projeto

Consolidar fundamentos de backend e boas práticas em .NET, priorizando:

-   Organização de código
-   Clareza arquitetural
-   Testabilidade
-   Separação de responsabilidades

------------------------------------------------------------------------

Desenvolvido para fins de estudo e aprimoramento contínuo.
