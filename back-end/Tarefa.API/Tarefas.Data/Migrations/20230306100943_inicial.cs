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
                values: new object[] { new Guid("4611557f-9a6f-4eae-9461-f86f25b41035"), "Em Desenvolvimento" });

            migrationBuilder.InsertData(
                table: "StatusTarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913"), "A Fazer" });

            migrationBuilder.InsertData(
                table: "StatusTarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb"), "Concluído" });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "DataPrevisao", "DataTermino", "Descricao", "StatusId" },
                values: new object[,]
                {
                    { new Guid("05acf3f9-0ef4-40c5-8a73-3fa9234cf432"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver Worker Service", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("0827b542-d795-467e-ac5b-a81588fff520"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adicionar logs para suporte da aplicação", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("12f491a4-2123-4834-90be-1c89a33e8378"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver front-end com Angular", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("2dbd507f-fa70-4fac-a635-9a8fecbbca85"), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documentar como utilizar o projeto README", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("438f32c1-2c7c-4486-aab8-602e3574862b"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver Web API", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("47b1d698-a5ce-4f3b-8f4c-3d43038325a4"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Definição do design front-end", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("594e7bd5-9399-48c3-9025-3ade929b0f07"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "(Extra) Containerizar toda a aplicação com docker compose", new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913") },
                    { new Guid("72638d5e-0920-4e8f-aa15-d87f5aad0ed6"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar conexão Web API + Worker", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("810fca9c-ab07-4a74-ad3b-cf540a74c54a"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Corrigir carregamento página ao trocar de status", new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913") },
                    { new Guid("a2d2a914-6209-43c0-88b8-09a2c5f3dc93"), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver POC do projeto", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("cb31a686-0e9f-44d9-94de-f5bfde8f1df7"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avaliar arquitetura do projeto", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("d6e94a16-ef78-4c02-a80b-d37cdebe23f0"), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "(Extra) Documentar utilização via container o projeto README", new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913") },
                    { new Guid("e9fc39ec-8faa-47f2-821c-871951786608"), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Versionar projeto GitHub", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") },
                    { new Guid("f266ddf0-74b8-48e3-b7be-a44a95c2aeed"), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Testar comunicação ponta a ponta", new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb") }
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
