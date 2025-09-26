using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TO_DO_LIST_WepAPI.Models.Entities;

namespace TO_DO_LIST_WepAPI.Data;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> Todo_Items { get; set; }
    public TodoDbContext(DbContextOptions options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { // Ignorar o aviso de mudanças pendentes no modelo e facilitar os testes

        optionsBuilder.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.ToTable("Todo_Items");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsCompleted).IsRequired();

            entity.Property(e => e.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()"); // Banco cuida da data de criação
        });

        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem
            {
                Id = 1,
                Title = "Configurar ambiente de desenvolvimento .NET",
                Description = "Instalar SDK, Visual Studio e configurar projeto",
                IsCompleted = true
            },
            new TodoItem
            {
                Id = 2,
                Title = "Implementar modelo TodoItem com Entity Framework",
                Description = "Criar classe model e configurações do DbContext",
                IsCompleted = true
            },
            new TodoItem
            {
                Id = 3,
                Title = "Criar API Controller com endpoints CRUD",
                Description = "Implementar GET, POST, PUT, DELETE para TodoItems",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 4,
                Title = "Testar endpoints com Swagger/Postman",
                Description = "Validar funcionamento de todas as operações CRUD",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 5,
                Title = "Implementar validações nos DTOs",
                Description = "Adicionar Data Annotations para validação de entrada",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 6,
                Title = "Configurar sistema de logging",
                Description = "Implementar serilog ou ILogger para monitoramento",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 7,
                Title = "Escrever documentação da API",
                Description = "Criar README com exemplos de uso e endpoints",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 8,
                Title = "Implementar tratamento de erros global",
                Description = "Criar middleware para Exception Handling",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 9,
                Title = "Criar testes unitários para o Service",
                Description = "Implementar xUnit ou MSTest para TodoService",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 10,
                Title = "Preparar apresentação do projeto",
                Description = "Organizar demonstração para avaliação técnica",
                IsCompleted = false
            }
        );
    }

}
