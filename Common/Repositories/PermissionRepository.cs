using ShopOnline.IDP.Common.Domains;
using ShopOnline.IDP.Entities;
using ShopOnline.IDP.PersistedDb;

namespace ShopOnline.IDP.Common.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission, long>, IPermissionRepositorry
    {
        public PermissionRepository(ShopOnlineIdentityContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        public Task<IEnumerable<Permission>> GetPermissionByRole(string roleId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermissionByRoleId(string roleId, IEnumerable<Permission> permissionCollection, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
