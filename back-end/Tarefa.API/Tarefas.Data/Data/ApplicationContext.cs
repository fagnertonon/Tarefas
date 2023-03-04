using Microsoft.EntityFrameworkCore;
using Tarefas.Core.Data;
using Tarefas.Data.Models;

namespace Tarefas.Data
{
    public sealed class ApplicationContext : DbContext, IUnitOfWork
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<StatusTarefa> StatusTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            new DbInitializer(modelBuilder).Seed();
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }
    }

}