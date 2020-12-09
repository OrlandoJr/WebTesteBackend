using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domain.Services
{

    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj).ConfigureAwait(true);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIDAsync(Guid ID)
        {
            return await _repository.GetByIDAsync(ID);
        }

        public async Task RemoveAsync(TEntity obj)
        {
            await _repository.RemoveAsync(obj);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await _repository.UpdateAsync(obj);
        }

        public async Task<bool> AnyAsync(TEntity obj)
        {
            return await _repository.AnyAsync(obj);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> obj)
        {
            await _repository.AddRangeAsync(obj);
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> obj)
        {
            await _repository.UpdateRangeAsync(obj);

        }
    }
}
