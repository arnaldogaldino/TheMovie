﻿
using System.Collections.Generic;

using TheMovie.Application.Interface;
using TheMovie.Domain.Entities;
using TheMovie.Domain.Interface.Services;

namespace TheMovie.Application
{
    public class FilmeAppService : AppServiceBase<Filme>, IFilmeAppService
    {
        private readonly IFilmeService filmeService;

        public FilmeAppService(IFilmeService filmeService)
            : base(filmeService)
        {
            this.filmeService = filmeService;
        }

        public void Desfavoritar(int id)
        {
            this.filmeService.Desfavoritar(id);
        }

        public void Favoritar(int id)
        {
            this.filmeService.Favoritar(id);
        }

        public IEnumerable<Filme> Favoritos()
        {
            return this.filmeService.Favoritos();
        }
    }
}
