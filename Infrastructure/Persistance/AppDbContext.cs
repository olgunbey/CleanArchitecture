using Application.Common;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    internal sealed class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }
        //public IQueryable<User> User => Set<User>().AsQueryable();

        //public IQueryable<Order> Order => Set<Order>().AsQueryable();

        public IQueryable<T> GetTableAsNoTracking<T>() where T : BaseEntity, new()
        {
            return Set<T>().AsNoTracking();
        }
        public IQueryable<T> GetTableNotAsNoTracking<T>() where T : BaseEntity, new()
        {
            return Set<T>();
        }
        public IQueryable<T> GetTableAsNoTrackingWithIdentityResolution<T>() where T : BaseEntity, new()
        {
            return Set<T>().AsNoTrackingWithIdentityResolution();
        }
    }
}
