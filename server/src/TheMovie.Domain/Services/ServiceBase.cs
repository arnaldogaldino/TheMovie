using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using TheMovie.Domain.Interface.Repositories;
using TheMovie.Domain.Interface.Services;

namespace TheMovie.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Adicionar(TEntity obj)
        {
            this.repository.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            this.repository.Atualizar(obj);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return this.repository.Buscar(predicate);
        }

        public TEntity ObterPorId(int id)
        {
            return this.repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return this.repository.ObterTodos();
        }

        public void Remover(int id)
        {
            this.repository.Remover(id);
        }

        public int SaveChanges()
        {
            return this.repository.SaveChanges();
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
    }
}
