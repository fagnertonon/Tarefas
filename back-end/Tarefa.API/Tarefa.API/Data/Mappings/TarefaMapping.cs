using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.API.Models;

namespace Tarefas.Data.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Data)
                    .IsRequired()
                    .HasColumnType("DATETIME");

            builder.Property(c => c.Status).IsRequired(true);

            builder.ToTable("Tarefas");
        }
    }
}