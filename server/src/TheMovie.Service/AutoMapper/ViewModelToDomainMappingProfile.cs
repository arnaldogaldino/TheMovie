using AutoMapper;

using TheMovie.Domain.Entities;
using TheMovie.Service.ViewModels;

namespace TheMovie.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FilmeViewModel, Filme>();
        }

    }
}
