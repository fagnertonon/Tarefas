using System;
using System.Linq.Expressions;
using Tarefas.Core.DomainObjects;

namespace Tarefas.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        void Adicionar(T model);
        void Atualizar(T model);
        void Excluir(T model);
        Task<T> ObterPorId(Guid Id);
        Task<bool> Existe(Guid Id);
        Task<IEnumerable<T>> ObterTodos();

        Task<IEnumerable<T>> Query(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<TModel>> Query<TModel>(Expression<Func<TModel, bool>> predicate) where TModel : Entity;

    }
}