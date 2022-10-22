
using System.Collections.Generic;

using TheMovie.Domain.Entities;

namespace TheMovie.Domain.Interface.Services
{
    public interface IFilmeService : IServiceBase<Filme>
    {
        void Favoritar(int id);
        void Desfavoritar(int id);
        IEnumerable<Filme> Favoritos();
    }
}
