using SurveyBucks.Internal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.Domain.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> Find(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
            int pageSize = 0, int pageNumber = 1);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdWithNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        void DeleteAsync(T entity);
        Task DeleteRange(IEnumerable<T> entities);
        Task<bool> Exists(int id);
    }
}
