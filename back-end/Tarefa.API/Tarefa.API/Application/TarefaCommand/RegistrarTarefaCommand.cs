using FluentValidation;
using System.Text.Json.Serialization;

namespace Tarefas.API.Application
{

    public class RegistrarTarefaCommand : TarefaCommand
    {
        [JsonIgnore]
        public override Guid Id { get ; set; }
        public override bool EhValido()
        {
            if (!base.EhValido()) return ValidationResult.IsValid;

            ValidationResult = new RegistrarTarefaValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public class RegistrarTarefaValidation : AbstractValidator<TarefaCommand>
        {
            public RegistrarTarefaValidation()
            {

            }
        }
    }
}