using TradingDDD.Infrastructure.Persistence;

namespace TradingDDD.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public TradingDbContext Context { get; }

        public UnitOfWork(TradingDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
