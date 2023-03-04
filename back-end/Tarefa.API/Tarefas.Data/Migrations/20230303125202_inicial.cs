using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefas.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusTarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: false),
                    DataPrevisao = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "DATE", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_StatusTarefas_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusTarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StatusTarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("212f1c70-5de2-41df-8c85-e36c30e89fe9"), "A Fazer" });

            migrationBuilder.InsertData(
                table: "StatusTarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("2ac70bb3-51b9-41ea-af72-cc9e173656f0"), "Em Desenvolvimento" });

            migrationBuilder.InsertData(
                table: "StatusTarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("4698842e-e9b6-4abf-af78-58c336bc4e36"), "Concluído" });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "DataPrevisao", "DataTermino", "Descricao", "StatusId" },
                values: new object[,]
                {
                    { new Guid("040258a2-44cc-4774-ba9a-d5f86eebfc18"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver POC do projeto", new Guid("4698842e-e9b6-4abf-af78-58c336bc4e36") },
                    { new Guid("1f3aa0b2-f206-49a5-8dfb-3ec8f0380f23"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver Web API", new Guid("4698842e-e9b6-4abf-af78-58c336bc4e36") },
                    { new Guid("34c1fd4c-08c6-41b0-99b7-b1439ad13419"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Testar comunicação ponta a ponta", new Guid("212f1c70-5de2-41df-8c85-e36c30e89fe9") },
                    { new Guid("3c69dfb9-7cbc-4d78-bd7d-6fe2650a9597"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avaliar arquitetura do projeto", new Guid("4698842e-e9b6-4abf-af78-58c336bc4e36") },
                    { new Guid("5483b675-437a-4271-89e0-743e4ddd7384"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adicionar logs para suporte da aplicação", new Guid("212f1c70-5de2-41df-8c85-e36c30e89fe9") },
                    { new Guid("63ae46d3-3861-4414-a08a-d92505d251d7"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "(Extra) Documentar utilização via container o projeto README", new Guid("212f1c70-5de2-41df-8c85-e36c30e89fe9") },
                    { new Guid("660ef6e7-35a4-4fbb-9937-af8c556251b3"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver Worker Service", new Guid("4698842e-e9b6-4abf-af78-58c336bc4e36") },
                    { new Guid("6a7ddd07-d46e-490e-bee4-40b310426772"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "(Extra) Containerizar toda a aplicação com docker compose", new Guid("212f1c70-5de2-41df-8c85-e36c30e89fe9") },
                    { new Guid("744e4db9-8180-479c-86b2-ea5848871cd6"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Definição do design front-end", new Guid("4698842e-e9b6-4abf-af78-58c336bc4e36") },
                    { new Guid("b28c8038-3589-4479-95d4-cdd5c648b903"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Desenvolver front-end com Angular", new Guid("2ac70bb3-51b9-41ea-af72-cc9e173656f0") },
                    { new Guid("b8ce2d75-73d1-404c-8cc4-8e621f742130"), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Documentar como utilizar o projeto README", new Guid("212f1c70-5de2-41df-8c85-e36c30e89fe9") },
                    { new Guid("d8a25c88-20d8-449e-aa2b-a03e9dd9d2f1"), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Versionar projeto GitHub", new Guid("212f1c70-5de2-41df-8c85-e36c30e89fe9") },
                    { new Guid("f0762883-5b76-4ec9-b710-fad70bbfe133"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar conexão Web API + Worker", new Guid("4698842e-e9b6-4abf-af78-58c336bc4e36") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_StatusId",
                table: "Tarefas",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "StatusTarefas");
        }
    }
}
