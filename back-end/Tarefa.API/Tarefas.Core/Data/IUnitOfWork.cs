using System.Threading.Tasks;

namespace Tarefas.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}