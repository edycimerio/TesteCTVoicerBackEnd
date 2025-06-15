# Chatbot Backend .NET

Backend para aplicação de chatbot desenvolvido em .NET 9 com arquitetura limpa e armazenamento em PostgreSQL.

## Requisitos

- .NET 9 SDK
- Docker e Docker Compose
- PostgreSQL (via Docker ou instalação local)

## Estrutura do Projeto

```
src/
  ├── ChatBot.Api           # API REST e controllers
  ├── ChatBot.Application   # Casos de uso e serviços de aplicação
  ├── ChatBot.Domain        # Entidades, interfaces e regras de negócio
  ├── ChatBot.Infrastructure # Implementações de persistência e serviços externos
  └── ChatBot.CrossCutting  # Componentes compartilhados e injeção de dependência
```

## Configuração do Banco de Dados

O projeto utiliza PostgreSQL em container Docker:

- **Porta**: 5433 (mapeada para 5432 no container)
- **Usuário**: postgres
- **Senha**: postgres
- **Banco de dados**: chatbotdb

## Como Executar

### 1. Iniciar o Banco de Dados com Docker

```bash
docker-compose up -d
```

Este comando inicia:
- PostgreSQL na porta 5433
- pgAdmin na porta 5051 (acesso: admin@chatbot.com / admin)

### 2. Executar as Migrações (se necessário)

```bash
cd src/ChatBot.Api
dotnet ef database update
```

### 3. Iniciar a API

```bash
cd src/ChatBot.Api
dotnet run
```

A API estará disponível em:
- HTTP: http://localhost:5161
- HTTPS: https://localhost:7178

## Endpoints da API

1. **Iniciar Conversa**
   - URL: `POST /api/conversation`
   - Retorno: GUID da conversa (string)

2. **Enviar Mensagem**
   - URL: `POST /api/message`
   - Corpo: `{ "conversationId": "guid-da-conversa", "message": "texto da mensagem" }`
   - Retorno: Resposta do bot (string)

3. **Obter Detalhes da Conversa**
   - URL: `GET /api/conversation/{id}`
   - Retorno: Objeto JSON com detalhes da conversa e mensagens

4. **Listar Conversas Ativas**
   - URL: `GET /api/conversation`
   - Retorno: Array de objetos de conversa

5. **Encerrar Conversa**
   - URL: `POST /api/conversation/{id}/end`
   - Retorno: Status 200 OK

## Scripts SQL

O repositório contém scripts SQL úteis:
- `create_tables.sql`: Cria as tabelas necessárias
- `check-tables.sql`: Verifica as tabelas existentes
- `recreate-tables.sql`: Recria as tabelas (apaga e cria novamente)
- `fix-database.sql`: Corrige problemas comuns no banco de dados

## Arquitetura

O backend utiliza:
- **Padrão CQRS**: Separação de comandos e consultas
- **MediatR**: Para implementação do padrão mediator
- **Entity Framework Core**: ORM para acesso ao banco de dados
- **Injeção de Dependência**: Para acoplamento fraco entre componentes
- **Swagger**: Documentação automática da API

## Licença

MIT
