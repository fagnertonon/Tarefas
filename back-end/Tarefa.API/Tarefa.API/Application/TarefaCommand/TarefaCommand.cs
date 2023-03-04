using Tarefas.Core.Messages;
using FluentValidation;

namespace Tarefas.API.Application
{
    public class TarefaCommand : Command
    {
        public virtual Guid Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime DataPrevisao { get; set; }
        public virtual Guid StatusId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new TarefaValidationBase().Validate(this);
            return ValidationResult.IsValid;
        }

        public class TarefaValidationBase : AbstractValidator<TarefaCommand>
        {
            public TarefaValidationBase()
            {
                RuleFor(c => c.Descricao)
                    .NotEmpty()
                    .WithMessage("Descrição não foi informado");

                RuleFor(c => c.DataPrevisao)
                        .NotEmpty()
                        .WithMessage("Data Prevista não foi informado");

                RuleFor(c => c.StatusId)
                        .NotEmpty()
                        .WithMessage("Status não foi informado");
            }
        }
    }
}