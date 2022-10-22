using AutoMapper;

using TheMovie.Domain.Entities;
using TheMovie.Service.ViewModels;

namespace TheMovie.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Filme, FilmeViewModel>();
        }
    }
}
