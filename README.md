# 🗂️ TaskManager API

API RESTful desenvolvida para gerenciamento de projetos, tarefas e comentários, com foco em controle, histórico de alterações e desempenho. Esta aplicação foi construída com .NET 8, seguindo princípios de Clean Architecture, utilizando CQRS e testes unitários.

---

## 🚀 Como executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [Docker](https://www.docker.com/)  
- [Docker Compose](https://docs.docker.com/compose/install/)

### Execução via Docker

```bash
docker-compose up --build
```

> A API estará disponível em `http://localhost:5000`

---

## 📦 Funcionalidades

### Usuário  
Pessoa que utiliza o aplicativo detentor de uma conta.

### Projeto  
Entidade que contém várias tarefas. Um usuário pode criar, visualizar e gerenciar vários projetos.

### Tarefa  
Unidade de trabalho dentro de um projeto. Cada tarefa possui:  
- Título  
- Descrição  
- Data de vencimento  
- Status (pendente, em andamento, concluída)  
- Prioridade (baixa, média, alta)

---

## 📌 Funcionalidades Implementadas (Sprint 1)

- ✅ Listar todos os projetos de um usuário  
- ✅ Visualizar todas as tarefas de um projeto específico  
- ✅ Criar novos projetos  
- ✅ Criar novas tarefas  
- ✅ Atualizar tarefas (status e detalhes)  
- ✅ Remover tarefas  
- ✅ Adicionar comentários nas tarefas  
- ✅ Registro de histórico de alterações por meio do `IMediator`

---

## ⚖️ Regras de Negócio

1. **Prioridade de Tarefas**  
   - A prioridade é obrigatória na criação e imutável após.

2. **Remoção de Projetos**  
   - Projetos com tarefas pendentes não podem ser removidos.

3. **Histórico de Atualizações**  
   - Toda atualização de tarefa ou comentário gera um evento registrado no histórico.

4. **Limite de Tarefas por Projeto**  
   - Máximo de 20 tarefas por projeto.

5. **Relatórios de Desempenho**  
   - Relatórios acessíveis apenas para usuários com função `gerente`.

6. **Comentários nas Tarefas**  
   - Comentários devem ser registrados no histórico da tarefa.

---

## 🧪 Testes

- ✅ Testes unitários cobrindo regras de negócio com **>80% de cobertura**
- Bibliotecas utilizadas:  
  - `xUnit`  
  - `Moq`  
  - `Shouldly`

### Executar os testes

```bash
dotnet test
```

---

## 🧰 Tecnologias Utilizadas

- .NET 8  
- Entity Framework Core  
- Dapper (opcional)  
- MediatR  
- Docker  
- Mysql 8.0 (ou outro banco de sua preferência)  
- xUnit, Moq, Shouldly  
- Clean Architecture + CQRS  

---

## 🔍 Fase 2: Perguntas para o PO

- Qual a regra de expiração para tarefas vencidas? Devem mudar automaticamente de status?  
- Comentários podem ser editados ou removidos?  
- O histórico deve ser visível para todos os usuários ou só para gerentes?  
- As tarefas podem ser atribuídas a múltiplos usuários?  
- Como devem ser calculadas as métricas de desempenho no relatório?  
- A criação de relatórios será assíncrona?  
- Haverá notificações por e-mail para status, comentários ou novas tarefas?

---

## 🌱 Fase 3: Melhorias Futuras

- 📦 Implementar autenticação via IdentityServer/Azure Entra ID  
- 🌐 Publicação em nuvem com CI/CD (ex: GitHub Actions + Azure App Service)  
- 📈 Dashboard com gráficos de desempenho (Blazor, Vue, etc.)  
- 🧱 Aplicar padrão de Domain Events mais formal com Event Sourcing  
- 🕵️‍♂️ Log centralizado com Serilog + Elastic Stack  
- ⚙️ Separação entre comandos e queries com medição de performance  
- ☁️ Estratégia multi-tenant e suporte para escalabilidade horizontal  

---

## 📁 Estrutura do Projeto

```text
/src
  /Application
  /Domain
  /Infrastructure
  /Persistence
  /WebApi
/tests
  /Application.Tests
```

---

## 📃 Licença

Este projeto está licenciado sob a MIT License.