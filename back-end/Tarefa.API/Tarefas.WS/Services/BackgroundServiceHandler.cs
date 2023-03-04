using FluentValidation.Results;
using Tarefas.Core.Data;

namespace Tarefas.WS.Services
{
    public abstract class BackgroundServiceHandler : BackgroundService
    {
        protected ValidationResult ValidationResult;

        protected BackgroundServiceHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
