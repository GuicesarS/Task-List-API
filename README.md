
# 📝 TO-DO LIST API – CRUD Completo em C# .NET

🚀 API REST desenvolvida em **.NET 8** com **Entity Framework Core** e **SQL Server**, criada para praticar conceitos essenciais de entrevistas técnicas e processos seletivos para vagas de **Desenvolvedor Back-end Júnior**.  

---

## 📌 Funcionalidades
- CRUD completo de tarefas (To-Do Items)  
- Banco de dados relacional (SQL Server)  
- Mapeamento objeto-relacional com Entity Framework Core  
- Documentação interativa com Swagger  
- Estrutura organizada com Services, DTOs e Repository Pattern  
- **Data Seeding com Fluent API** (banco já populado ao subir a aplicação)  

---

## ⚙️ Tecnologias Utilizadas
- **.NET 8**  
- **Entity Framework Core**  
- **SQL Server**  
- **Swagger / OpenAPI**  
- **Dependency Injection**  
- **Git + GitHub** para versionamento  

---

## 📂 Estrutura do Projeto
```

TO-DO-LIST-API/
├── Controllers/    # Endpoints REST
├── Models/         # Entidades e DTOs
├── Data/           # DbContext e configurações
├── Services/       # Lógica de negócio
└── Migrations/     # Controle do schema do banco

````

---

## 🚀 Como Executar o Projeto

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/GuicesarS/Task-List-API.git
````

### 2️⃣ Configurar a conexão com o SQL Server

No arquivo **appsettings.json**, ajuste sua connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodoDb;User Id=sa;Password=SuaSenha;"
}
```

### 3️⃣ Executar as migrations

```bash
dotnet ef database update
```

### 4️⃣ Rodar a aplicação

```bash
dotnet run
```

---

## 📖 Documentação da API

Após rodar o projeto, acesse o Swagger no navegador.
Lá você encontra todos os endpoints disponíveis:

* **GET** `/api/Todo` → Lista todas as tarefas
* **POST** `/api/Todo` → Cria uma nova tarefa
* **GET** `/api/Todo/{id}` → Busca tarefa por ID
* **PUT** `/api/Todo/{id}` → Atualiza tarefa existente
* **DELETE** `/api/Todo/{id}` → Remove tarefa

---

## 📊 Exemplo de Data Seeding (Produtividade)

No `DbContext`, o banco já é populado com tarefas de exemplo:

```csharp
modelBuilder.Entity<TodoItem>().HasData(
    new TodoItem { Id = 1, Title = "Configurar ambiente .NET", IsCompleted = true },
    new TodoItem { Id = 2, Title = "Implementar API Controller", IsCompleted = false }
);
```

🎯 Assim, ao subir a aplicação já é possível testar todos os endpoints imediatamente.

---

## 🎯 Objetivo

Este projeto foi desenvolvido com foco em:

* Praticar habilidades exigidas em entrevistas técnicas
* Demonstrar **boas práticas de código**
* Mostrar **produtividade em tempo limitado** (simulando desafios de 1h/1h30 em entrevistas ao vivo)
* Servir como base para evoluir (ex: autenticação JWT, testes automatizados, etc.)

---

## 📌 Próximos Passos

* [ ] Implementar autenticação JWT
* [ ] Adicionar testes automatizados (xUnit / MSTest)

---

## 📬 Contato
🔗 [LinkedIn](https://www.linkedin.com/in/guicesarss/)

```
