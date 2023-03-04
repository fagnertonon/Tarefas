using Microsoft.EntityFrameworkCore;
using Tarefas.Data.Repository;
using Tarefas.Core.Data;
using Tarefas.Data.Models;

namespace Tarefas.Data.Repository
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        private readonly ApplicationContext _context;

        public TarefaRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Tarefa>> ObterTodos()
        {
            return await _context.Tarefas.Include(x => x.Status).ToListAsync();
        }
        public new async Task<Tarefa> ObterPorId(Guid Id)
        {
            return await _context.Tarefas.Include(x => x.Status).Where(x => x.Id == Id).SingleOrDefaultAsync();
        }
        public async Task<StatusTarefa> ObterStatus(string status)
        {
            return await _context.StatusTarefas.Where(x => x.Descricao == status).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<StatusTarefa>> ObterStatus()
        {
            return await _context.StatusTarefas.OrderBy(x=>x.Descricao).ToListAsync();
        }
    }
}