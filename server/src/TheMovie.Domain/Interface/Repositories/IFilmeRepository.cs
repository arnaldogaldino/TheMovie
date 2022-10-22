
using System.Collections.Generic;

using TheMovie.Domain.Entities;

namespace TheMovie.Domain.Interface.Repositories
{
    public interface IFilmeRepository : IRepositoryBase<Filme>
    {
        void Favoritar(int id);
        void Desfavoritar(int id);
        IEnumerable<Filme> Favoritos();
    }
}
