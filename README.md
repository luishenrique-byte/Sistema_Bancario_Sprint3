# 🏦 uBank — Sistema Bancário Digital

> Sistema bancário completo com API REST em **ASP.NET Core**, autenticação JWT, persistência em MySQL e frontend moderno com Tailwind CSS.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-10.0-512BD4?style=flat-square&logo=dotnet)
![MySQL](https://img.shields.io/badge/MySQL-8.x-4479A1?style=flat-square&logo=mysql&logoColor=white)
![JWT](https://img.shields.io/badge/Auth-JWT_Bearer-000000?style=flat-square&logo=jsonwebtokens)
![Swagger](https://img.shields.io/badge/Docs-Swagger_UI-85EA2D?style=flat-square&logo=swagger&logoColor=black)
![HTML5](https://img.shields.io/badge/Frontend-HTML5_CSS_JS-E34C26?style=flat-square&logo=html5&logoColor=white)

---

## 📋 Índice

- [1. Descrição do Projeto](#1-descrição-do-projeto)
- [2. Tecnologias Utilizadas](#2-tecnologias-utilizadas)
- [3. Instruções de Execução](#3-instruções-de-execução)
- [4. Endpoints da API](#4-endpoints-da-api)
- [5. Fluxo de Autenticação](#5-fluxo-de-autenticação)
- [6. Estrutura do Projeto](#6-estrutura-do-projeto)
- [7. Modelos de Dados](#7-modelos-de-dados)
- [8. Funcionalidades Principais](#8-funcionalidades-principais)
- [9. Segurança](#9-segurança)
- [10. Troubleshooting](#10-troubleshooting)

---

## 1. Descrição do Projeto

O **uBank** é um sistema bancário digital completo que simula operações essenciais de um banco moderno. O projeto foi desenvolvido em **ASP.NET Core** para o backend com integração de um frontend responsivo em **HTML/CSS/JavaScript**.

### Principais Características

✅ **Autenticação segura** via JWT Bearer Token (validade 2 horas)  
✅ **Cadastro de clientes** (Pessoa Física e Jurídica)  
✅ **Gerenciamento de contas** (Corrente, Poupança e Empresarial)  
✅ **Transações financeiras** (Depósito, Saque e Transferência)  
✅ **Extrato bancário** com histórico completo  
✅ **Pix** integrado para transferências instantâneas  
✅ **Suporte a múltiplas contas** por cliente  
✅ **Limite de crédito** para contas empresariais  
✅ **Taxas e juros** configuráveis por tipo de conta  
✅ **API RESTful** com documentação Swagger interativa  
✅ **Frontend responsivo** com design moderno (Tailwind CSS + Font Awesome)

---

## 2. Tecnologias Utilizadas

### 2.1 Backend

| Tecnologia | Versão | Finalidade |
|---|---|---|
| **.NET** | 10.0 | Runtime |
| **ASP.NET Core** | 10.0 | Framework web |
| **Entity Framework Core** | 8.0.20 | ORM para persistência |
| **Pomelo MySQL Provider** | 8.0.2 | Conector MySQL |
| **JWT Bearer** | 10.0.7 | Autenticação |
| **Swagger/OpenAPI** | 6.5.0 | Documentação de API |
| **BCrypt.NET** | 0.1.0 | Hash de senhas |

### 2.2 Banco de Dados

| Componente | Descrição |
|---|---|
| **SGBD** | MySQL 8.x |
| **Database** | `Sistema_Bancario` |
| **Servidor** | `localhost` |
| **Porta** | `3306` |
| **Usuário padrão** | `root` |
| **Senha padrão** | `cimatec` |

### 2.3 Frontend

| Tecnologia | Versão | Finalidade |
|---|---|---|
| **HTML5** | - | Estrutura |
| **Tailwind CSS** | 3.x | Estilização |
| **Font Awesome** | 6.4.0 | Ícones |
| **JavaScript Vanilla** | ES6+ | Interatividade |

### 2.4 Segurança

| Componente | Descrição |
|---|---|
| **JWT Bearer** | Token com validade de 2 horas |
| **BCrypt** | Hash de senhas com salt |
| **CORS** | Configurado para aceitar requisições do frontend |
| **HTTPS** | Suportado na porta 7044 |

---

## 3. Instruções de Execução

### 3.1 Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [MySQL 8.x](https://dev.mysql.com/downloads/mysql/)
- [Git](https://git-scm.com/)
- Um editor (Visual Studio, Visual Studio Code ou similiar)

### 3.2 Passo 1: Clonar o Repositório

```bash
git clone <url-do-repositorio>
cd Sistema_Bancario_Sprint3
```

### 3.3 Passo 2: Configurar o Banco de Dados

Certifique-se de que o MySQL está rodando:

```bash
# Windows (cmd)
net start MySQL80

# Linux/macOS
brew services start mysql
# ou
sudo systemctl start mysql
```

Crie o banco de dados manualmente (opcional, as migrations farão isso):

```sql
CREATE DATABASE Sistema_Bancario CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE Sistema_Bancario;
```

### 3.4 Passo 3: Restaurar Dependências

```bash
cd Sistema_Bancario_Sprint3
dotnet restore
```

### 3.5 Passo 4: Aplicar as Migrations

```bash
dotnet tool restore
dotnet ef database update
```

Isso criará todas as tabelas no banco de dados:
- `Usuarios`
- `Clientes`
- `Contas`
- `TipoContas`
- `Transacoes`

### 3.6 Passo 5: Iniciar a Aplicação

```bash
dotnet run
```

A aplicação iniciará em:
- **HTTP:** http://localhost:5092
- **HTTPS:** https://localhost:7044

### 3.7 Passo 6: Acessar a Aplicação

**API Swagger:** https://localhost:7044/swagger  
**Frontend:** https://localhost:7044/ (ou pasta de frontend configurada)

### 3.8 Primeiros Passos

1. Abra a página inicial (`index.html`)
2. Clique em **"Abra sua conta"**
3. Cadastre-se com email e senha
4. Preencha os dados pessoais e escolha o tipo de conta
5. Faça login e acesse o painel de controle

---

## 4. Endpoints da API

### 4.1 Autenticação (`/api/Auth`)

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `POST` | `/api/Auth/login` | ❌ | Faz login e retorna JWT Token |
| `POST` | `/api/Auth/register` | ❌ | Cadastra novo usuário |

**Exemplo - Login:**
```bash
curl -X POST https://localhost:7044/api/Auth/login \
  -H "Content-Type: application/json" \
  -d '{"usuario":"user@email.com","senha":"senha123"}'
```

**Resposta:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "mensagem": "Login bem-sucedido!",
  "precisaCompletarCadastro": false
}
```

---

### 4.2 Clientes (`/api/Clientes`)

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `GET` | `/api/Clientes` | ❌ | Lista todos os clientes |
| `GET` | `/api/Clientes/{id}` | ❌ | Busca cliente por ID |
| `GET` | `/api/Clientes/buscar-por-chave?chave=...` | ✅ | Busca cliente por chave Pix |
| `POST` | `/api/Clientes` | ✅ | Cadastra novo cliente |
| `PUT` | `/api/Clientes/{id}` | ✅ | Atualiza dados do cliente |
| `DELETE` | `/api/Clientes/{id}` | ✅ | Deleta cliente |

**Exemplo - Cadastrar Cliente:**
```bash
curl -X POST https://localhost:7044/api/Clientes \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer <seu_token>" \
  -d '{
    "nome": "João Silva",
    "email": "joao@email.com",
    "telefone": "(11) 99999-9999",
    "cpfCnpj": "123.456.789-00",
    "tipoPessoa": 0
  }'
```

---

### 4.3 Contas (`/api/contas`)

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `GET` | `/api/contas` | ❌ | Lista todas as contas |
| `GET` | `/api/contas/{id}` | ❌ | Busca conta por ID |
| `GET` | `/api/contas/minhas-contas` | ✅ | Retorna contas do usuário logado |
| `GET` | `/api/contas/por-cliente/{clienteId}` | ✅ | Retorna contas de um cliente |
| `POST` | `/api/contas` | ✅ | Cria nova conta |
| `PUT` | `/api/contas/{id}` | ✅ | Atualiza dados da conta |
| `DELETE` | `/api/contas/{id}` | ✅ | Encerra conta |

**Exemplo - Criar Conta:**
```bash
curl -X POST https://localhost:7044/api/contas \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer <seu_token>" \
  -d '{
    "idCliente": 1,
    "idTipoConta": 1
  }'
```

---

### 4.4 Transações (`/api/Transacao`)

| Método | Rota | Auth | Descrição |
|---|---|---|---|
| `POST` | `/api/Transacao/post` | ✅ | Realiza transação (depósito, saque, transferência) |
| `GET` | `/api/Transacao` | ❌ | Lista todas as transações |
| `GET` | `/api/Transacao/extrato/{contaId}` | ❌ | Extrato completo da conta |

**Exemplo - Realizar Transferência:**
```bash
curl -X POST https://localhost:7044/api/Transacao/post \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer <seu_token>" \
  -d '{
    "idContaOrigem": 1,
    "idContaDestino": 2,
    "valor": 100.00,
    "tipo": 2
  }'
```

**Tipos de Transação:**
- `0` = Depósito
- `1` = Saque
- `2` = Transferência

---

## 5. Fluxo de Autenticação

```
┌─────────────────┐
│   Usuário       │
└────────┬────────┘
         │
         ├──→ Cadastro (email + senha)
         │         │
         │         └──→ POST /api/Auth/register
         │              └──→ BCrypt Hash de senha
         │
         └──→ Login (email + senha)
                  │
                  └──→ POST /api/Auth/login
                       ├─ Valida credenciais
                       ├─ Gera JWT Token (2h válidade)
                       ├─ Retorna token + precisaCompletarCadastro
                       │
                       ├─ SE precisaCompletarCadastro = true
                       │  └──→ Preencher dados pessoais
                       │       └──→ Escolher tipo de conta
                       │            └──→ POST /api/Clientes + /api/contas
                       │
                       └─ SE precisaCompletarCadastro = false
                          └──→ Direto para home.html
```

**Fluxo Completo de Onboarding:**
1. `index.html` → Landing page
2. `cadastro.html` → Cria usuário (POST /api/Auth/register)
3. `login.html` → Login e recebe token (POST /api/Auth/login)
4. `completar-cadastro.html` → Cria cliente (POST /api/Clientes)
5. Cria conta automaticamente (POST /api/contas)
6. `home.html` → Painel principal

---

## 6. Estrutura do Projeto

```
Sistema_Bancario_Sprint3/
│
├── Controllers/                    # Controladores (rotas HTTP)
│   ├── AuthController.cs
│   ├── ClientesController.cs
│   ├── ContasController.cs
│   └── TransacaoController.cs
│
├── Services/                       # Lógica de negócio
│   ├── login/
│   │   ├── IAuthService.cs
│   │   └── AuthService.cs
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
├── Repositories/                   # Acesso a dados
│   ├── usuario/
│   │   ├── IUsuarioRepository.cs
│   │   └── UsuarioRepository.cs
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
├── Models/                         # Entidades do domínio
│   ├── Usuario.cs
│   ├── Cliente.cs
│   ├── Conta.cs
│   ├── TipoConta.cs
│   ├── Transacao.cs
│   └── ENUM/
│       ├── TipoPessoa.cs
│       ├── TipoTransacao.cs
│       └── Status.cs
│
├── DTOs/                           # Objetos de transferência
│   ├── login/
│   │   ├── LoginRequestDTO.cs
│   │   └── LoginResponseDTO.cs
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
├── Data/                           # Contexto EF Core
│   ├── AppDbContext.cs
│   └── Mappings/
│       ├── UsuarioMap.cs
│       ├── ClienteMap.cs
│       ├── ContaMap.cs
│       └── TransacaoMap.cs
│
├── Migrations/                     # Histórico de migrations
│
├── wwwroot/                        # Frontend estático
│   ├── index.html
│   ├── login.html
│   ├── cadastro.html
│   ├── completar-cadastro.html
│   ├── home.html
│   ├── transferencias.html
│   ├── extrato.html
│   ├── depositos-saques.html
│   └── pix.html
│
├── Program.cs                      # Configuração da app
├── appsettings.json                # Variáveis de ambiente
└── README.md                        # Este arquivo
```

---

## 7. Modelos de Dados

### 7.1 Usuario

```csharp
public class Usuario
{
    public long Id { get; set; }
    public string Email { get; set; }              // Único
    public string SenhaHash { get; set; }          // BCrypt hash
    public Role Role { get; set; }                 // Admin ou Cliente
    public long? IdCliente { get; set; }           // FK para Cliente
    public DateTime DataCadastro { get; set; }
}
```

### 7.2 Cliente

```csharp
public class Cliente
{
    public long Id { get; set; }
    public string Nome { get; set; }               // 100 caracteres max
    public string Email { get; set; }              // Único
    public string Telefone { get; set; }
    public TipoPessoa TipoPessoa { get; set; }    // 0=PF, 1=PJ
    public string cpfCnpj { get; set; }            // Único
    public DateTime DataCadastro { get; set; }
    
    public ICollection<Conta> Contas { get; set; }
}
```

### 7.3 Conta

```csharp
public class Conta
{
    public long Id { get; set; }
    public string NumeroConta { get; set; }
    public string Agencia { get; set; }
    public decimal Saldo { get; set; }
    public Status Status { get; set; }             // 1=Ativa, 0=Bloqueada
    public DateTime DataAbertura { get; set; }
    
    public long IdCliente { get; set; }            // FK
    public Cliente Cliente { get; set; }
    
    public long IdTipoConta { get; set; }          // FK
    public TipoConta TipoConta { get; set; }
    
    // Campos específicos por tipo
    public string? CnpjVinculado { get; set; }     // Para contas PJ
    public decimal? LimiteCredito { get; set; }    // Para empresariais
    public decimal? TaxaJuros { get; set; }        // Para poupança
    public int? DiaRendimento { get; set; }        // Para poupança
    
    public ICollection<Transacao> TransacoesOrigem { get; set; }
    public ICollection<Transacao> TransacoesDestino { get; set; }
}
```

### 7.4 TipoConta

```csharp
public class TipoConta
{
    public long Id { get; set; }
    public string Nome { get; set; }               // "Corrente", "Poupança", "Empresarial"
    public string Descricao { get; set; }
}
```

**IDs Padrão:**
- `1` = Conta Corrente
- `2` = Conta Poupança
- `3` = Conta Empresarial

### 7.5 Transacao

```csharp
public class Transacao
{
    public long Id { get; set; }
    public TipoTransacao Tipo { get; set; }        // 0=Depósito, 1=Saque, 2=Transferência
    public decimal Valor { get; set; }
    public DateTime DataHora { get; set; }
    
    public long IdContaOrigem { get; set; }        // FK
    public Conta ContaOrigem { get; set; }
    
    public long? IdContaDestino { get; set; }      // FK (nullable)
    public Conta? ContaDestino { get; set; }
}
```

---

## 8. Funcionalidades Principais

### 8.1 Autenticação e Autorização

✅ Registro de novo usuário com hash BCrypt  
✅ Login com email e senha  
✅ Geração de JWT Token com 2h de validade  
✅ Claims incluem email e role do usuário  
✅ Validação de token em endpoints protegidos  
✅ Refresh automático de claims em cada requisição

### 8.2 Gerenciamento de Clientes

✅ Cadastro de Pessoa Física (CPF)  
✅ Cadastro de Pessoa Jurídica (CNPJ)  
✅ Validação automática de email único  
✅ Busca por chave Pix (para transações)  
✅ Atualização de dados pessoais  
✅ Vinculação automática com usuário

### 8.3 Gerenciamento de Contas

✅ Criação de múltiplas contas por cliente  
✅ Suporte a 3 tipos de conta:
  - **Corrente:** Sem limite de crédito
  - **Poupança:** Com taxa de juros e dia de rendimento
  - **Empresarial:** Com limite de crédito e CNPJ vinculado

✅ Geração automática de número de conta e agência  
✅ Controle de status (ativa/bloqueada/encerrada)  
✅ Histórico de saldo por data

### 8.4 Transações Financeiras

✅ **Depósito:** Adiciona saldo à conta  
✅ **Saque:** Remove saldo com validação  
✅ **Transferência:** Entre contas (mesma instituição)  
✅ Validação de saldo insuficiente  
✅ Registro completo de histórico  
✅ Extrato com filtros por data e tipo

### 8.5 Frontend (Frontend SPA)

✅ Landing page responsiva (`index.html`)  
✅ Sistema de cadastro (`cadastro.html`)  
✅ Login com JWT (`login.html`)  
✅ Completar cadastro (`completar-cadastro.html`)  
✅ Painel principal (`home.html`)  
✅ Transferências (`transferencias.html`)  
✅ Extrato (`extrato.html`)  
✅ Depósitos e saques (`depositos-saques.html`)  
✅ Pix integrado (`pix.html`)

---

## 9. Segurança

### 9.1 Autenticação

| Aspecto | Implementação |
|---|---|
| **Hash de Senhas** | BCrypt com salt aleatório |
| **Token JWT** | HS256, 2h de validade |
| **Email** | Campo único na tabela Usuários |
| **HTTPS** | Suportado na porta 7044 |

### 9.2 Autorização

| Aspecto | Implementação |
|---|---|
| **Endpoints Protegidos** | Atributo `[Authorize]` no controller |
| **Claims** | Email e Role extraídos do JWT |
| **Validação de Propriedade** | Extração do email do JWT para operações de cliente |

### 9.3 Validação de Dados

| Aspecto | Implementação |
|---|---|
| **Entrada HTTP** | Validação de tipos e ranges |
| **SQL Injection** | EF Core com Parametric Queries |
| **CORS** | Configurado para aceitar frontend |
| **Erros** | Mensagens genéricas em produção |

### 9.4 Práticas Recomendadas

✅ Nunca exponha senhas em logs  
✅ Use HTTPS em produção  
✅ Rotacione tokens regularmente  
✅ Valide entrada do usuário em ambas as camadas  
✅ Use prepared statements (EF Core já faz isso)  

---

## 10. Troubleshooting

### Problema: "Connection refused" ao conectar no MySQL

**Solução:**
```bash
# Verifique se MySQL está rodando
mysql -u root -p

# Se não estiver rodando
# Windows
net start MySQL80

# Linux/macOS
brew services start mysql
```

### Problema: "Database not found" na migration

**Solução:**
```bash
# A migration cria o banco automaticamente
# Se não funcionou, crie manualmente
mysql -u root -p cimatec -e "CREATE DATABASE Sistema_Bancario;"

# Depois rode a migration
dotnet ef database update
```

### Problema: Porta 7044 já está em uso

**Solução:**
```bash
# Altere a porta em appsettings.json
"Kestrel": {
  "Endpoints": {
    "Https": {
      "Url": "https://localhost:7045"
    }
  }
}
```

### Problema: Token JWT inválido no Swagger

**Solução:**
1. Faça login em `/api/Auth/login`
2. Copie o valor do campo `token`
3. Clique no botão **Authorize** (cadeado)
4. Cole o token no campo (sem "Bearer ")
5. Clique em **Authorize**

### Problema: Erro CORS ao acessar frontend

**Solução:**
Verifique o `Program.cs`:
```csharp
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
```

### Problema: Senha não está sendo hasheada

**Solução:**
Certifique-se de que está usando `BCrypt.Net.BCrypt.HashPassword()` no `AuthService.cs`:
```csharp
SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha)
```

### Problema: Usuário não consegue fazer login

**Solução:**
1. Verifique se o usuário foi criado com `POST /api/Auth/register`
2. Confirme que `PrecisaCompletarCadastro` é `false` no banco
3. Valide as credenciais no Swagger

---

## 📞 Suporte

Para dúvidas ou problemas:

1. Consulte a documentação Swagger: `https://localhost:7044/swagger`
2. Verifique os logs da aplicação
3. Valide as credenciais do MySQL
4. Confirme que o .NET 10 SDK está instalado

---

## 📜 Licença

Este projeto é parte da avaliação da **Sprint 4** do curso FORD <Enter>.

---

## ✨ Equipe

- **Desenvolvedor Backend:** [Luís Henrique Freitas Mendes]
- **Desenvolvedor Frontend:** [Luís Henrique Freitas Mendes]
- **Arquiteto:** [Luís Henrique Freitas Mendes]

---

**Última atualização:** 2025-05-26
**Status:** ✅ Production Ready