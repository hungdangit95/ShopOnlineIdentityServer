using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ShopOnline.IDP.Common.Domains;
using ShopOnline.IDP.Entities;
using ShopOnline.IDP.PersistedDb;

namespace ShopOnline.IDP.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public UserManager<User> UserManager { get; }
        public RoleManager<User> RoleManager { get; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShopOnlineIdentityContext _dbContext;
        

        public RepositoryManager(IUnitOfWork unitOfWork, 
            ShopOnlineIdentityContext dbContext, 
            UserManager<User> userManager,
            RoleManager<User> roleManager)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
            => _dbContext.Database.BeginTransactionAsync();

        public Task EndTransactionAsync() => _dbContext.Database.CommitTransactionAsync();

        public void RollbackTransaction() => _dbContext.Database.RollbackTransactionAsync();

        public Task<int> SaveAsync()=> _unitOfWork.CommitAsync();
    }
}
