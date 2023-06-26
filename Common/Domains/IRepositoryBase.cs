using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace ShopOnline.IDP.Common.Domains
{
    public interface IRepositoryBase<T,K> where T : EntityBase<K>
    {
        #region Query
        IQueryable<T> FindAll(bool trackChanges = false);
        IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false,
            params Expression<Func<T, object>>[] includeProperties);

        Task<T?> GetByIdAsync(K id);
        Task<T?> GetByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties);
        #endregion

        #region Action 
        Task<K> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateListAsync(IEnumerable<T> entities);
        Task DeleteListAsync(IEnumerable<T> entities);
        #endregion

        #region Transaction
        Task<int> SaveChangeAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task EndTransactionAsync();
        Task RollbackTransactionAsync();
        #endregion
    }
}
