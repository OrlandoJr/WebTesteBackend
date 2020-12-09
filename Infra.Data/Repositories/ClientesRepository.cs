using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;


namespace Infra.Data.Repositories
{
    public class ClientesRepository : RepositoryBase<ClientesModel>, IClientesRepository
    {
        public ClientesRepository(BaseDBContext context) : base(context)
        {
        }

    }
}
