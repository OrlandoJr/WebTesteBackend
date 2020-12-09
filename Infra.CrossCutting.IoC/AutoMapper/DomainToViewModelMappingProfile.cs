using Application.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Infra.CrossCutting.IoC
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClientesModel, ClientesViewModel>();

            CreateMap<ClientesViewModel, ClientesPutViewModel>();
            CreateMap<ClientesViewModel, ClientesPostViewModel>();


        }
    }
}
