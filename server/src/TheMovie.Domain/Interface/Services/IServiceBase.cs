using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TheMovie.Domain.Interface.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        void Dispose();
    }
}
