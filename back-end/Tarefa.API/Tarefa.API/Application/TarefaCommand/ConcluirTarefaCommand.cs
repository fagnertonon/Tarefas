using FluentValidation;
using System.Text.Json.Serialization;

namespace Tarefas.API.Application
{
    public class ConcluirTarefaCommand : TarefaCommand
    {
        [JsonIgnore]
        public virtual string Descricao { get; set; }
        [JsonIgnore]
        public virtual DateTime DataPrevista { get; set; }
        [JsonIgnore]
        public virtual Guid StatusId { get; set; }

        public ConcluirTarefaCommand(Guid id)
        {
           Id = id;
        }
        public override bool EhValido()
        {
            ValidationResult = new ConcluirClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class ConcluirClienteValidation : AbstractValidator<TarefaCommand>
        {
            public ConcluirClienteValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id da tarefa inválido");
            }
        }
    }
}