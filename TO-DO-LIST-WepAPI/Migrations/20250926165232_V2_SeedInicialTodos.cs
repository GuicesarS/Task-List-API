using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TO_DO_LIST_WepAPI.Migrations
{
    /// <inheritdoc />
    public partial class V2_SeedInicialTodos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo_Items",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Todo_Items",
                columns: new[] { "Id", "CreatedAt", "Description", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7048), "Instalar SDK, Visual Studio e configurar projeto", true, "Configurar ambiente de desenvolvimento .NET" },
                    { 2, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7589), "Criar classe model e configurações do DbContext", true, "Implementar modelo TodoItem com Entity Framework" },
                    { 3, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7590), "Implementar GET, POST, PUT, DELETE para TodoItems", false, "Criar API Controller com endpoints CRUD" },
                    { 4, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7641), "Validar funcionamento de todas as operações CRUD", false, "Testar endpoints com Swagger/Postman" },
                    { 5, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7642), "Adicionar Data Annotations para validação de entrada", false, "Implementar validações nos DTOs" },
                    { 6, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7643), "Implementar serilog ou ILogger para monitoramento", false, "Configurar sistema de logging" },
                    { 7, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7644), "Criar README com exemplos de uso e endpoints", false, "Escrever documentação da API" },
                    { 8, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7644), "Criar middleware para Exception Handling", false, "Implementar tratamento de erros global" },
                    { 9, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7645), "Implementar xUnit ou MSTest para TodoService", false, "Criar testes unitários para o Service" },
                    { 10, new DateTime(2025, 9, 26, 16, 52, 31, 848, DateTimeKind.Utc).AddTicks(7646), "Organizar demonstração para avaliação técnica", false, "Preparar apresentação do projeto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Todo_Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo_Items",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
