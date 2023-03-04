using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Data.Models;

namespace Tarefas.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.DataPrevisao)
                    .IsRequired()
                    .HasColumnType("DATE");

            builder.Property(c => c.DataTermino)
                   .HasColumnType("DATE");

            builder.HasOne(x => x.Status)
                  .WithMany(x => x.Tarefas)
                  .HasForeignKey(x => x.StatusId);

            builder.ToTable("Tarefas");
        }
    }
}