using TradingDDD.Infrastructure.Data.Model;

namespace TradingDDD.Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> InsertAsync(T entity);
        public Task<bool> RemoveByIdAsync(int id);
        public Task<T> UpdateAsync(T identity);
        public Task<List<T>> PaginationAsync(PaginationFilter paginationFilter);
        public Task<int> GetCountAsync();
    }
}
