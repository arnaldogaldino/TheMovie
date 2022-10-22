using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using TheMovie.Application.Interface;
using TheMovie.Domain.Entities;
using TheMovie.Service.ViewModels;

namespace TheMovie.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeAppService filmeAppService;
        private readonly IMapper mapper;

        public FilmeController(IFilmeAppService filmeAppService,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.filmeAppService = filmeAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] FilmeViewModel filmeViewModel)
        {
            this.filmeAppService.Adicionar(mapper.Map<Filme>(filmeViewModel));            
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] FilmeViewModel filmeViewModel)
        {
            this.filmeAppService.Adicionar(mapper.Map<Filme>(filmeViewModel));
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public FilmeViewModel Get(int id)
        {
            return this.mapper.Map<FilmeViewModel>(this.filmeAppService.ObterPorId(id));
        }

        [HttpGet]
        [Route("favoritos")]
        public IEnumerable<FilmeViewModel> Favoritos()
        {
            return this.mapper.Map<IEnumerable<FilmeViewModel>>(this.filmeAppService.Favoritos());
        }

        [HttpGet]
        [Route("favoritar/{id:int}")]
        public IActionResult Favoritar(int id)
        {
            this.filmeAppService.Favoritar(id);
            return Ok();
        }

        [HttpGet]
        [Route("desfavoritar/{id:int}")]
        public IActionResult Desfavoritar(int id)
        {
            this.filmeAppService.Desfavoritar(id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            this.filmeAppService.Remover(id);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<FilmeViewModel> Get()
        {
            return this.mapper.Map<IEnumerable<FilmeViewModel>>(this.filmeAppService.ObterTodos());
        }
    }
}
