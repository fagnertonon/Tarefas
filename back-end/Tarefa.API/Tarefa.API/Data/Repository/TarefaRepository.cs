using Microsoft.EntityFrameworkCore;
using Tarefas.API.Data.Repository;
using Tarefas.Core.Data;
using Tarefas.API.Models;

namespace Tarefas.Data.Data.Repository
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        private readonly ApplicationContext _context;

        public TarefaRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}