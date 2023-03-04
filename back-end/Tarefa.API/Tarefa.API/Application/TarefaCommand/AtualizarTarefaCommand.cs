using System;
using FluentValidation;

namespace Tarefas.API.Application
{
    public class AtualizarTarefaCommand : TarefaCommand
    {
        public AtualizarTarefaCommand()
        {
           
        }
        public override bool EhValido()
        {
            if (!base.EhValido()) return ValidationResult.IsValid;

            ValidationResult = new AtualizarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarClienteValidation : AbstractValidator<TarefaCommand>
        {
            public AtualizarClienteValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id da tarefa inválido");
            }
        }
    }
}