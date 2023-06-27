using ShopOnline.IDP.Common.Domains;
using ShopOnline.IDP.Entities;

namespace ShopOnline.IDP.Common.Repositories
{
    public interface IPermissionRepositorry : IRepositoryBase<Permission, long>
    {
        Task<IEnumerable<Permission>> GetPermissionByRole(string roleId, bool trackChanges);
        void UpdatePermissionByRoleId(string roleId, IEnumerable<Permission>permissionCollection)
        {

        }
    }
    
}
