﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarefas.Data;

#nullable disable

namespace Tarefas.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tarefas.Data.Models.StatusTarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusTarefas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913"),
                            Descricao = "A Fazer"
                        },
                        new
                        {
                            Id = new Guid("4611557f-9a6f-4eae-9461-f86f25b41035"),
                            Descricao = "Em Desenvolvimento"
                        },
                        new
                        {
                            Id = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb"),
                            Descricao = "Concluído"
                        });
                });

            modelBuilder.Entity("Tarefas.Data.Models.Tarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPrevisao")
                        .HasColumnType("DATE");

                    b.Property<DateTime?>("DataTermino")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Tarefas", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cb31a686-0e9f-44d9-94de-f5bfde8f1df7"),
                            DataPrevisao = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Avaliar arquitetura do projeto",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("47b1d698-a5ce-4f3b-8f4c-3d43038325a4"),
                            DataPrevisao = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Definição do design front-end",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("a2d2a914-6209-43c0-88b8-09a2c5f3dc93"),
                            DataPrevisao = new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Desenvolver POC do projeto",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("438f32c1-2c7c-4486-aab8-602e3574862b"),
                            DataPrevisao = new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Desenvolver Web API",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("05acf3f9-0ef4-40c5-8a73-3fa9234cf432"),
                            DataPrevisao = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Desenvolver Worker Service",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("72638d5e-0920-4e8f-aa15-d87f5aad0ed6"),
                            DataPrevisao = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Criar conexão Web API + Worker",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("12f491a4-2123-4834-90be-1c89a33e8378"),
                            DataPrevisao = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Desenvolver front-end com Angular",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("f266ddf0-74b8-48e3-b7be-a44a95c2aeed"),
                            DataPrevisao = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Testar comunicação ponta a ponta",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("e9fc39ec-8faa-47f2-821c-871951786608"),
                            DataPrevisao = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Versionar projeto GitHub",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("2dbd507f-fa70-4fac-a635-9a8fecbbca85"),
                            DataPrevisao = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Documentar como utilizar o projeto README",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("594e7bd5-9399-48c3-9025-3ade929b0f07"),
                            DataPrevisao = new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "(Extra) Containerizar toda a aplicação com docker compose",
                            StatusId = new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913")
                        },
                        new
                        {
                            Id = new Guid("d6e94a16-ef78-4c02-a80b-d37cdebe23f0"),
                            DataPrevisao = new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "(Extra) Documentar utilização via container o projeto README",
                            StatusId = new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913")
                        },
                        new
                        {
                            Id = new Guid("0827b542-d795-467e-ac5b-a81588fff520"),
                            DataPrevisao = new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataTermino = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Adicionar logs para suporte da aplicação",
                            StatusId = new Guid("b19e94db-0799-44fe-9519-d342f4e9d9bb")
                        },
                        new
                        {
                            Id = new Guid("810fca9c-ab07-4a74-ad3b-cf540a74c54a"),
                            DataPrevisao = new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Corrigir carregamento página ao trocar de status",
                            StatusId = new Guid("54a73b46-fd83-4a6f-86bf-fc0c7b0cf913")
                        });
                });

            modelBuilder.Entity("Tarefas.Data.Models.Tarefa", b =>
                {
                    b.HasOne("Tarefas.Data.Models.StatusTarefa", "Status")
                        .WithMany("Tarefas")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Tarefas.Data.Models.StatusTarefa", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
