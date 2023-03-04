using FluentValidation;
using System.Text.Json.Serialization;

namespace Tarefas.API.Application
{
    public class DesenvolverTarefaCommand : TarefaCommand
    {
        [JsonIgnore]
        public virtual string Descricao { get; set; }
        [JsonIgnore]
        public virtual DateTime DataPrevista { get; set; }
        [JsonIgnore]
        public virtual Guid StatusId { get; set; }

        public DesenvolverTarefaCommand(Guid id)
        {
           Id = id;
        }
        public override bool EhValido()
        {
            ValidationResult = new DesenvolverClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DesenvolverClienteValidation : AbstractValidator<TarefaCommand>
        {
            public DesenvolverClienteValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id da tarefa inválido");
            }
        }
    }
}