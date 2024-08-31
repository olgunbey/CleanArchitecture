﻿using Domain.Common;
using Domain.Entities;

namespace Application.Common
{
    public interface IApplicationDbContext
    {
        //public IQueryable<User> User { get; }
        //public IQueryable<Order> Order { get; }

        public IQueryable<T> GetTableAsNoTracking<T>() where T : BaseEntity, new();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IQueryable<T> GetTableNotAsNoTracking<T>() where T : BaseEntity, new();
        IQueryable<T> GetTableAsNoTrackingWithIdentityResolution<T>() where T : BaseEntity, new();
    }
}
