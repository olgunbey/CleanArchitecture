using Application.Common;
using Domain;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    internal sealed class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

        public IQueryable<T> GetTable<T>(GetTableEnum getTableEnum) where T : BaseEntity, new()
        {

           return getTableEnum switch
            {
                GetTableEnum.AsNoTracking => Set<T>().AsNoTracking(),
                GetTableEnum.NotAsNoTracking => Set<T>(),
                GetTableEnum.AsNoTrackingWithIdentityResolution => Set<T>().AsNoTrackingWithIdentityResolution()
            };
        }
       
    }
}
