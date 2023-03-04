using System.Text.Json.Serialization;
using FluentValidation;

namespace Tarefas.API.Application
{
    public class ExcluirTarefaCommand : TarefaCommand
    {
        [JsonIgnore]
        public virtual string Descricao { get; set; }
        [JsonIgnore]
        public virtual DateTime DataPrevista { get; set; }
        [JsonIgnore]
        public virtual Guid StatusId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new ExcluirClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public ExcluirTarefaCommand(Guid id)
        {
            this.Id = id;
        }
        public class ExcluirClienteValidation : AbstractValidator<ExcluirTarefaCommand>
        {
            public ExcluirClienteValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id da tarefa inválido");
            }
        }
    }
}