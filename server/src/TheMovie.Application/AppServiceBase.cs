using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using TheMovie.Application.Interface;
using TheMovie.Domain.Interface.Services;

namespace TheMovie.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Adicionar(TEntity obj)
        {
            this._serviceBase.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            this._serviceBase.Atualizar(obj);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return this._serviceBase.Buscar(predicate);
        }

        public TEntity ObterPorId(int id)
        {
            return this._serviceBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return this._serviceBase.ObterTodos();
        }

        public void Remover(int id)
        {
            this._serviceBase.Remover(id);
        }

        public int SaveChanges()
        {
            return this._serviceBase.SaveChanges();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

    }
}
