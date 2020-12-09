using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(TEntity obj);
        Task<bool> AnyAsync(TEntity obj);
        void Dispose();
        Task<TEntity> GetByIDAsync(Guid ID);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddRangeAsync(IEnumerable<TEntity> obj);
        Task UpdateRangeAsync(IEnumerable<TEntity> obj);
    }
}
