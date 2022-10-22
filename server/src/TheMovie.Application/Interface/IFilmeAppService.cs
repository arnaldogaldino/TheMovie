
using System.Collections.Generic;

using TheMovie.Domain.Entities;

namespace TheMovie.Application.Interface
{
    public interface IFilmeAppService : IAppServiceBase<Filme>
    {
        void Favoritar(int id);
        void Desfavoritar(int id);
        IEnumerable<Filme> Favoritos();
    }
}
