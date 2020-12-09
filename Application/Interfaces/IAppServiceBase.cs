
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task<IActionResult> AddAsync(TEntity obj);
        Task<IActionResult> UpdateAsync(TEntity obj);
        Task<IActionResult> RemoveAsync(Guid Id);
        Task<bool> AnyAsync(TEntity obj);
        void Dispose();
        Task<IActionResult> GetByIDAsync(Guid Id);
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> AddRangeAsync(IEnumerable<TEntity> obj);
        Task<IActionResult> UpdateRangeAsync(IEnumerable<TEntity> obj);
    }
}
