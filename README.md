# Sistema Bancário — Sprint 3

> API REST de um sistema bancário desenvolvida com **ASP.NET Core (.NET 10)**, com autenticação JWT, persistência em MySQL e documentação interativa via Swagger.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-10.0-512BD4?style=flat-square&logo=dotnet)
![MySQL](https://img.shields.io/badge/MySQL-8.x-4479A1?style=flat-square&logo=mysql&logoColor=white)
![JWT](https://img.shields.io/badge/Auth-JWT_Bearer-000000?style=flat-square&logo=jsonwebtokens)
![Swagger](https://img.shields.io/badge/Docs-Swagger_UI-85EA2D?style=flat-square&logo=swagger&logoColor=black)

---

## Sumário

- [Sobre o projeto](#sobre-o-projeto)
- [Links de acesso](#links-de-acesso)
- [Credenciais de acesso](#credenciais-de-acesso)
- [Tecnologias e versões](#tecnologias-e-versões)
- [Arquitetura](#arquitetura)
- [Modelos de dados](#modelos-de-dados)
- [Endpoints da API](#endpoints-da-api)
- [Como rodar o projeto](#como-rodar-o-projeto)

---

## Sobre o projeto

O **Sistema Bancário** é uma API que simula operações essenciais de um banco digital:

- Cadastro e gerenciamento de **clientes** (Pessoa Física e Jurídica)
- Abertura e gerenciamento de **contas bancárias** (com suporte a tipos de conta, limite de crédito e taxa de juros)
- Realização de **transações financeiras**: depósito, saque e transferência entre contas
- Consulta de **extrato** por conta
- **Autenticação** via JWT Bearer Token com validade de 2 horas

---

## Links de acesso

| Interface | URL |
|---|---|
| API (HTTP) | http://localhost:5092 |
| API (HTTPS) | https://localhost:7044 |
| **Swagger UI** | **https://localhost:7044/swagger** |
| Swagger UI (HTTP) | http://localhost:5092/swagger |

> O Swagger é a interface principal para explorar e testar todos os endpoints da API de forma interativa.

---

## Credenciais de acesso

A autenticação é feita via `POST /api/auth/login`:

| Campo | Valor |
|---|---|
| Usuário | `admin` |
| Senha | `123456` |

**Exemplo de body para o login:**

```json
{
  "usuario": "admin",
  "senha": "123456"
}
```

O endpoint retorna um **JWT Token** com validade de **2 horas**. Para acessar os endpoints protegidos, inclua o token no header:

```
Authorization: Bearer <seu_token_aqui>
```

> No Swagger, clique no botão **Authorize** (cadeado) no topo da página, cole o token no campo e confirme.

---

## Tecnologias e versões

### Runtime

| Tecnologia | Versão |
|---|---|
| .NET | 10.0 |
| ASP.NET Core | 10.0 |

### Pacotes NuGet

| Pacote | Versão | Finalidade |
|---|---|---|
| `Microsoft.AspNetCore.Authentication.JwtBearer` | 10.0.7 | Autenticação via JWT Bearer Token |
| `Microsoft.EntityFrameworkCore.Tools` | 8.0.20 | Migrations e CLI do EF Core |
| `Pomelo.EntityFrameworkCore.MySql` | 8.0.2 | Provedor MySQL para o Entity Framework Core |
| `Swashbuckle.AspNetCore` | 6.5.0 | Geração automática do Swagger/OpenAPI |

### Ferramentas .NET (dotnet-tools.json)

| Ferramenta | Versão | Uso |
|---|---|---|
| `dotnet-ef` | 10.0.7 | CLI para criação e execução de migrations |

### Banco de dados

| Configuração | Valor padrão |
|---|---|
| SGBD | MySQL 8.x |
| Database | `Sistema_Bancario` |
| Servidor | `localhost` |
| Usuário | `root` |
| Senha | `cimatec` |

---

## Arquitetura

O projeto segue o padrão de **Arquitetura em Camadas** com separação clara de responsabilidades entre Controllers, Services e Repositories.

```
Sistema_Bancario_Sprint3/
├── Controllers/              # Camada de entrada — recebe e roteia as requisições HTTP
│   ├── AuthController.cs
│   ├── ClientesController.cs
│   ├── ContasController.cs
│   └── TransacaoController.cs
│
├── Services/                 # Camada de negócio — regras e lógicas da aplicação
│   ├── cliente/
│   │   ├── IClienteService.cs
│   │   └── ClienteService.cs
│   ├── conta/
│   │   ├── IContaService.cs
│   │   └── ContaService.cs
│   └── transacao/
│       ├── ITransacaoService.cs
│       └── TransacaoService.cs
│
├── Repositories/             # Camada de dados — comunicação com o banco via EF Core
│   ├── cliente/
│   │   ├── IClienteRepository.cs
│   │   └── ClienteRepository.cs
│   ├── conta/
│   │   ├── IContaRepository.cs
│   │   └── ContaRepository.cs
│   └── transacao/
│       ├── ITransacaoRepository.cs
│       └── TransacaoRepository.cs
│
├── Models/                   # Entidades do domínio
│   ├── Cliente.cs
│   ├── Conta.cs
│   ├── TipoConta.cs
│   ├── Transacao.cs
│   └── enum/
│       ├── Status.cs
│       ├── TipoPessoa.cs
│       └── TipoTransacao.cs
│
├── DTOs/                     # Objetos de transferência de dados (request/response)
│   ├── LoginDTO.cs
│   ├── cliente/
│   │   ├── ClienteRequestDTO.cs
│   │   └── ClienteResponseDTO.cs
│   ├── conta/
│   │   ├── ContaRequestDTO.cs
│   │   └── ContaResponseDTO.cs
│   └── transacao/
│       ├── TransacaoRequestDTO.cs
│       └── TransacaoResponseDTO.cs
│
├── Data/                     # Contexto do EF Core e mapeamentos Fluent API
│   ├── AppDbContext.cs
│   └── Mappings/
│       ├── ClienteMap.cs
│       ├── ContaMap.cs
│       └── TransacaoMap.cs
│
├── Migrations/               # Histórico de migrações do banco de dados
├── Program.cs                # Configuração da aplicação e injeção de dependência
└── appsettings.json          # Configurações (connection string, JWT)
```

### Fluxo de uma requisição

```
Requisição HTTP
    └─► Controller   (valida entrada, chama o Service)
            └─► Service      (aplica regras de negócio, chama o Repository)
                    └─► Repository   (executa queries via EF Core)
                                └─► MySQL
```

Todas as interfaces e implementações de Services e Repositories são registradas via **injeção de dependência** com escopo `Scoped` em `Program.cs`.

---

## Modelos de dados

### Cliente

| Campo | Tipo | Descrição |
|---|---|---|
| `Id` | `long` | Identificador único |
| `Nome` | `string` | Nome completo |
| `Email` | `string` | E-mail |
| `Telefone` | `string` | Telefone de contato |
| `TipoPessoa` | `enum` | `PF` (Pessoa Física) ou `PJ` (Pessoa Jurídica) |
| `cpfCnpj` | `string` | CPF ou CNPJ |
| `DataCadastro` | `DateTime` | Data de cadastro |

### Conta

| Campo | Tipo | Descrição |
|---|---|---|
| `Id` | `long` | Identificador único |
| `NumeroConta` | `string` | Número da conta |
| `Agencia` | `string` | Agência |
| `Saldo` | `decimal` | Saldo atual |
| `Status` | `enum` | `ativa`, `bloqueada` ou `encerrada` |
| `DataAbertura` | `DateTime` | Data de abertura |
| `IdCliente` | `long` | FK — cliente titular |
| `IdTipoConta` | `long` | FK — tipo de conta |
| `CnpjVinculado` | `string?` | CNPJ vinculado (exclusivo PJ) |
| `LimiteCredito` | `decimal?` | Limite de crédito |
| `TaxaJuros` | `decimal?` | Taxa de juros |
| `DiaRendimento` | `int?` | Dia de rendimento mensal |

### Transação

| Campo | Tipo | Descrição |
|---|---|---|
| `Id` | `long` | Identificador único |
| `Tipo` | `enum` | `Deposito`, `Saque` ou `Tranferencia` |
| `Valor` | `decimal` | Valor da operação |
| `DataHora` | `DateTime` | Data e hora da transação |
| `IdContaOrigem` | `long` | FK — conta de origem |
| `IdContaDestino` | `long?` | FK — conta de destino (somente em transferências) |

---

## Endpoints da API

### Autenticação

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `POST` | `/api/auth/login` | Não | Gera o JWT Token |

### Clientes

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `GET` | `/api/clientes` | Não | Lista todos os clientes |
| `GET` | `/api/clientes/{id}` | Não | Busca cliente por ID |
| `POST` | `/api/clientes` | **Sim** | Cadastra um novo cliente |
| `PUT` | `/api/clientes/{id}` | **Sim** | Atualiza dados de um cliente |
| `DELETE` | `/api/clientes/{id}` | **Sim** | Remove um cliente |

### Contas

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `GET` | `/api/contas` | Não | Lista todas as contas |
| `GET` | `/api/contas/{id}` | Não | Busca conta por ID |
| `POST` | `/api/contas` | **Sim** | Abre uma nova conta |
| `PUT` | `/api/contas/{id}` | **Sim** | Atualiza dados de uma conta |
| `DELETE` | `/api/contas/{id}` | **Sim** | Encerra uma conta |

### Transações

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `POST` | `/api/transacao` | **Sim** | Realiza uma transação (depósito, saque ou transferência) |
| `GET` | `/api/transacao` | Não | Lista todas as transações |
| `GET` | `/api/transacao/extrato/{contaId}` | Não | Retorna o extrato de uma conta |

---

## Como rodar o projeto

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MySQL 8.x rodando localmente na porta padrão `3306`

### 1. Clone o repositório

```bash
git clone <url-do-repositorio>
cd Sistema_Bancario_Sprint3
```

### 2. Configure o banco de dados

Certifique-se de que o MySQL está rodando com o usuário `root` e senha `cimatec`. O banco `Sistema_Bancario` será criado automaticamente pelas migrations.

Se necessário, ajuste a connection string em `Sistema_Bancario_Sprint3/appsettings.json`:

```json
"ConnectionStrings": {
  "ConexaoPadrao": "Server=Localhost;DataBase=Sistema_Bancario;Uid=root;Pwd=cimatec"
}
```

### 3. Instale a ferramenta dotnet-ef (se necessário)

```bash
dotnet tool restore
```

### 4. Execute as migrations

```bash
cd Sistema_Bancario_Sprint3
dotnet ef database update
```

### 5. Inicie a aplicação

```bash
dotnet run
```

A API estará disponível em:
- HTTP: http://localhost:5092
- HTTPS: https://localhost:7044

### 6. Acesse o Swagger

Abra no navegador: **https://localhost:7044/swagger**

### 7. Autentique-se

1. No Swagger, localize o endpoint `POST /api/auth/login`
2. Clique em **Try it out** e envie o body:
```json
{
  "usuario": "admin",
  "senha": "123456"
}
```
3. Copie o valor do campo `token` da resposta
4. Clique no botão **Authorize** (cadeado) no topo da página do Swagger
5. Cole o token no campo e confirme — agora todos os endpoints protegidos estão liberados
