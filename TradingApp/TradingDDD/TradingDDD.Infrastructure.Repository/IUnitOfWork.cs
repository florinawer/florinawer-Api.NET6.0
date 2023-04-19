using TradingDDD.Infrastructure.Persistence;

namespace TradingDDD.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public TradingDbContext Context { get; }

        public void Commit();
    }
}
