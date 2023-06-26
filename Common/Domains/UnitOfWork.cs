using ShopOnline.IDP.PersistedDb;

namespace ShopOnline.IDP.Common.Domains
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopOnlineIdentityContext _context;

        public UnitOfWork(ShopOnlineIdentityContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return  _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
