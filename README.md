# 🧠 Ryze CRM - Backend

Back-end do **Ryze CRM**, um sistema de gerenciamento de relacionamento com clientes focado em **automação do funil de vendas**, **captura de leads**, e **eficiência para times comerciais**.

## 🚀 Tecnologias

- ASP.NET Core 9
- Entity Framework Core
- Clean Architecture
- Postgres
- AutoMapper
- FluentValidation
- Swagger
- JWT Authentication
- Docker

## 📁 Estrutura do Projeto (Clean Architecture)

src/
├── Ryze.CRM.Web # Camada de apresentação (controllers, middlewares)
├── Ryze.CRM.Application # Regras de negócio (casos de uso, DTOs, interfaces)
├── Ryze.CRM.Domain # Entidades e enums
└── Ryze.CRM.Infrastructure # Banco de dados, serviços externos, implementações

## ⚙️ Como rodar

### Pré-requisitos

- .NET 9 SDK
- Docker (opcional, para banco de dados)
- SQL Server ou PostgreSQL

### Passos

```bash
# Clonar o projeto
[git clone https://github.com/seuusuario/ryze-crm-backend.git](https://github.com/eoBraad/Ryze.git)
cd Ryze

# Restaurar pacotes
dotnet restore

# Aplicar migrações e atualizar banco
dotnet ef database update --startup-project ./src/Ryze.Web  --project ./src/Ryze.Infrastructure

# Rodar o servidor
dotnet run --project ./src/Ryze.Web
