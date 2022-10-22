
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
            // Comentario do rafael
            // Comentario do Arnaldo
            return this.filmeService.Favoritos();
        }

        public void ArnaldoTeste1() {

        }
        
        public void ArnaldoTeste2() {

        }
        
        public void RafaelTeste2() {

        }

        public void RafaelTeste3() {

    }
    }

}
