using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using TheMovie.Infrastructure.Data.Context;
using TheMovie.Domain.Entities;
using TheMovie.Domain.Interface.Repositories;

namespace TheMovie.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity<TEntity>
    {
        protected TheMovieSQLContext Db;
        protected DbSet<TEntity> DbSet;
        protected Repository(TheMovieSQLContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public TEntity ObterPorId(int id)
        {
            var result = DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
            return result;
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
