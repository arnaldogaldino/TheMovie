using Dapper;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using TheMovie.Infrastructure.Data.Context;
using TheMovie.Domain.Entities;
using TheMovie.Domain.Interface.Repositories;

namespace TheMovie.Infrastructure.Data.Repositories
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(TheMovieSQLContext context) : base(context)
        {

        }

        public void Favoritar(int id)
        {
            var filme = this.ObterPorId(id);
            filme.Favorito = true;
            this.Atualizar(filme);
        }

        public void Desfavoritar(int id)
        {
            var filme = this.ObterPorId(id);
            filme.Favorito = false;
            this.Atualizar(filme);
        }

        public IEnumerable<Filme> Favoritos()
        {
            var sql = "SELECT * FROM FILMES E WHERE FAVORITO = 1";

            return Db.Database.GetDbConnection().Query<Filme>(sql);
        }

        public IEnumerable<Filme> ObterTodos()
        {
            var sql = "SELECT * FROM FILMES E ";

            return Db.Database.GetDbConnection().Query<Filme>(sql);
        }
    }
}
