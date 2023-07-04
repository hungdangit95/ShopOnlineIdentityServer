using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ShopOnline.IDP.Common.Domains;
using ShopOnline.IDP.Entities;
using ShopOnline.IDP.PersistedDb;

namespace ShopOnline.IDP.Common.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShopOnlineIdentityContext _dbContext;
        public readonly Lazy<IPermissionRepositorry> _permission;


        public RepositoryManager(IUnitOfWork unitOfWork, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager,
            ShopOnlineIdentityContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            UserManager = userManager;
            RoleManager = roleManager;
            _permission = new Lazy<IPermissionRepositorry>(() => new PermissionRepository(_dbContext, unitOfWork)
           );
        }
        public IPermissionRepositorry Permission => _permission.Value;

        public Task<IDbContextTransaction> BeginTransactionAsync()
            => _dbContext.Database.BeginTransactionAsync();

        public Task EndTransactionAsync() => _dbContext.Database.CommitTransactionAsync();

        public void RollbackTransaction() => _dbContext.Database.RollbackTransactionAsync();

        public Task<int> SaveAsync() => _unitOfWork.CommitAsync();
    }
}
