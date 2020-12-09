using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ClientesService : ServiceBase<ClientesModel>, IClientesService
    {
        private readonly IClientesRepository _repository;

        public ClientesService(IClientesRepository repository) : base(repository)
        {
            _repository = repository;
        }


    }
}
