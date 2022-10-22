using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using TheMovie.Domain.Entities;
using TheMovie.Domain.Interface.Repositories;
using TheMovie.Domain.Interface.Services;

namespace TheMovie.Domain.Services
{
    public class FilmeService : ServiceBase<Filme>, IFilmeService
    {
        private readonly IFilmeRepository filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
            : base(filmeRepository)
        {
            this.filmeRepository = filmeRepository;
        }

        public void Desfavoritar(int id)
        {
            this.filmeRepository.Desfavoritar(id);
        }

        public void Favoritar(int id)
        {
            this.filmeRepository.Favoritar(id);
        }

        public IEnumerable<Filme> Favoritos()
        {
            return this.filmeRepository.Favoritos();
        }
    }
}
