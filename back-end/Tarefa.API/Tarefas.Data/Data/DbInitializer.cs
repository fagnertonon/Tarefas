using Microsoft.EntityFrameworkCore;
using Tarefas.Data.Models;

namespace Tarefas.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {

            StatusTarefa aFazer = new StatusTarefa() { Id = Guid.NewGuid(), Descricao = "A Fazer" };
            StatusTarefa emDesenvolvimento = new StatusTarefa() { Id = Guid.NewGuid(), Descricao = "Em Desenvolvimento" };
            StatusTarefa concluido = new StatusTarefa() { Id = Guid.NewGuid(), Descricao = "Concluído" };

            var arquitetura = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Avaliar arquitetura do projeto",
                DataPrevisao = new DateTime(2023, 3, 1),
                DataTermino = new DateTime(2023, 3, 2),
                StatusId = concluido.Id
            };

            var definicaoDesign = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Definição do design front-end",
                DataPrevisao = new DateTime(2023, 3, 1),
                DataTermino = new DateTime(2023, 3, 2),
                StatusId = concluido.Id
            };
            var poc = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Desenvolver POC do projeto",
                DataPrevisao = new DateTime(2023, 3, 2),
                DataTermino = new DateTime(2023, 3, 2),
                StatusId = concluido.Id
            };
            var webAPI = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Desenvolver Web API",
                DataPrevisao = new DateTime(2023, 3, 2),
                DataTermino = new DateTime(2023, 3, 3),
                StatusId = concluido.Id
            };
            var workerService = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Desenvolver Worker Service",
                DataPrevisao = new DateTime(2023, 3, 3),
                DataTermino = new DateTime(2023, 3, 3),
                StatusId = concluido.Id
            };
            var conexaoWeAPIeWorker = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Criar conexão Web API + Worker",
                DataPrevisao = new DateTime(2023, 3, 3),
                DataTermino = new DateTime(2023, 3, 3),
                StatusId = concluido.Id
            };
            var frontEnd = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Desenvolver front-end com Angular",
                DataPrevisao = new DateTime(2023, 3, 3),
                DataTermino =  new DateTime(2023,3,4),
                StatusId = concluido.Id
            };
            var tarefa8 = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Testar comunicação ponta a ponta",
                DataPrevisao = new DateTime(2023, 3, 3),
                DataTermino = new DateTime(2023, 3, 4),
                StatusId = concluido.Id
            };
            var versionar = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Versionar projeto GitHub",
                DataPrevisao = new DateTime(2023, 3, 4),
                DataTermino = new DateTime(2023, 3, 4),
                StatusId = concluido.Id
            };
            var documentarReadme = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Documentar como utilizar o projeto README",
                DataPrevisao = new DateTime(2023, 3, 4),
                DataTermino = new DateTime(2023, 3, 4),
                StatusId = concluido.Id
            };
            var containerizacao = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "(Extra) Containerizar toda a aplicação com docker compose",
                DataPrevisao = new DateTime(2023, 3, 5),
                StatusId = aFazer.Id
            };
            var documentarContainer = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "(Extra) Documentar utilização via container o projeto README",
                DataPrevisao = new DateTime(2023, 3, 5),
                StatusId = aFazer.Id
            };
            var adicionarLogs = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Adicionar logs para suporte da aplicação",
                DataPrevisao = new DateTime(2023, 3, 5),
                DataTermino = new DateTime(2023,3,4),
                StatusId = concluido.Id
            };
            var correcaoLoadAoSalvar = new Tarefa
            {
                Id = Guid.NewGuid(),
                Descricao = "Corrigir carregamento página ao trocar de status",
                DataPrevisao = new DateTime(2023, 3, 5),
                StatusId = aFazer.Id
            };

            modelBuilder.Entity<StatusTarefa>().HasData(
                aFazer
                , emDesenvolvimento
                , concluido
             );

            modelBuilder.Entity<Tarefa>().HasData(
                arquitetura
                , definicaoDesign
                , poc
                , webAPI
                , workerService
                , conexaoWeAPIeWorker
                , frontEnd
                , tarefa8
                , versionar
                , documentarReadme
                , containerizacao
                , documentarContainer
                , adicionarLogs
                , correcaoLoadAoSalvar
            );
        }
    }

}