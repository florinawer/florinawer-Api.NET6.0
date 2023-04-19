using Microsoft.EntityFrameworkCore;
using TradingDDD.Infrastructure.Data.Model;
using TradingDDD.Infrastructure.Repository.Interfaces;

namespace TradingDDD.Infrastructure.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await _unitOfWork.Context.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> RemoveByIdAsync(int id)
        {
            var dbEntity = await _unitOfWork.Context.Set<T>().FindAsync(id);
            if (dbEntity != null)
            {
                _unitOfWork.Context.Set<T>().Remove(dbEntity);
                return true;
            }
            return false;
        }

        public virtual Task<T> UpdateAsync(T identity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<T>> PaginationAsync(PaginationFilter paginationFilter)
        {
            var data = await _unitOfWork.Context.Set<T>()
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
            return data;
        }

        public virtual async Task<int> GetCountAsync()
        {
            return await _unitOfWork.Context.Set<T>().CountAsync();
        }
    }
}
