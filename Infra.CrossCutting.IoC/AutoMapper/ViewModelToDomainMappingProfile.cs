using Application.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Infra.CrossCutting.IoC
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            
            CreateMap<ClientesViewModel, ClientesModel>();

            CreateMap<ClientesPutViewModel,  ClientesViewModel>();
            CreateMap<ClientesPostViewModel, ClientesViewModel>();

        }
    }
}