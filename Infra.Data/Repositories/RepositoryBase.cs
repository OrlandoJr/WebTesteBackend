using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;


namespace Infra.Data.Repositories
{
        public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
        {
            #region RepositoryBase
            protected readonly BaseDBContext _context;

            public RepositoryBase(BaseDBContext context)
            {
                _context = context;
            }

            public virtual async Task AddRangeAsync(IEnumerable<TEntity> obj)
            {
                try
                {
                    _context.ChangeTracker.LazyLoadingEnabled = false;
                    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    _context.ChangeTracker.AutoDetectChangesEnabled = false;

                    await _context.BulkInsertAsync(obj.ToList());

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Set<TEntity>().Any())
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }

            }

            public virtual async Task AddAsync(TEntity obj)
            {
                try
                {

                    _context.ChangeTracker.LazyLoadingEnabled = false;
                    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    _context.ChangeTracker.AutoDetectChangesEnabled = false;                    

                    await _context.Set<TEntity>().AddAsync(obj);
                    await _context.SaveChangesAsync();


                    //var keyName = _context.Model.FindEntityType(typeof(TEntity))
                    //                            .FindPrimaryKey().Properties
                    //                            .Select(x => x.Name).Single();

                    //return (string)obj.GetType().GetProperty(keyName).GetValue(obj, null);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Set<TEntity>().Any())
                    {
                        return ;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            public virtual async Task UpdateAsync(TEntity obj)
            {
                try
                {
                    _context.Entry(obj).State = EntityState.Modified;
                    _context.Update(obj);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Set<TEntity>().Any())
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> obj)
            {
                try
                {
                    await _context.BulkUpdateAsync(obj.ToList());

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Set<TEntity>().Any())
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            public virtual async Task RemoveAsync(TEntity obj)
            {
                _context.Set<TEntity>().Remove(obj);
                await _context.SaveChangesAsync();
            }

            public virtual void Dispose()
            {
                _context.Dispose();
            }

            public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            {
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }

            public virtual async Task<TEntity> GetByIDAsync(Guid ID)
            {
                return await _context.Set<TEntity>().FindAsync(ID);
            }

            public virtual async Task<bool> AnyAsync(TEntity obj)
            {
                return await _context.Set<TEntity>().AsNoTracking().AnyAsync(x => x == obj);
            }

            #endregion
        }
    
}
