using Tarefas.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tarefas.Core.Data;
using Tarefas.Core.DomainObjects;

namespace Tarefas.API.Data.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> DbSet;

        public IUnitOfWork UnitOfWork => _context;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }
        public void Adicionar(T model)
        {
            DbSet.Add(model);
        }

        public void Atualizar(T model)
        {
            DbSet.Update(model);
        }

        public void Excluir(T model)
        {
            DbSet.Remove(model);

        }
        public async Task<bool> Existe(Guid id)
        {
            return await DbSet.AnyAsync(x => x.Id == id);
        }

        public virtual async Task<T> ObterPorId(Guid Id)
        {
            return await DbSet.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
     
        public async Task<IQueryable<T>> ObterTodosQueryable()
        {
            return DbSet.AsQueryable();
        }
        public async Task<IQueryable<TModel>> ObterTodosQueryable<TModel>() where TModel : Entity
        {
            var dbSet = _context.Set<TModel>();

            return dbSet.AsQueryable();
        }
        public async Task<IEnumerable<T>> Query(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public async Task<IEnumerable<TModel>> Query<TModel>(Expression<Func<TModel, bool>> predicate) where TModel : Entity
        {
            var dbSet = _context.Set<TModel>();

            return dbSet.Where(predicate);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}