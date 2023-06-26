﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ShopOnline.IDP.Entities;

namespace ShopOnline.IDP.Repositories
{
    public interface IRepositoryManager
    {
        UserManager<User> UserManager { get; }
        RoleManager<User> RoleManager { get; }
        Task<int> SaveAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task EndTransactionAsync();
        void RollbackTransaction();
    }
}
