using Application.Common;
using Domain;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Persistance
{
    internal sealed class AppDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
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


        public void Test(Func<Expression<Func<Order, bool>>, Order> func, Expression<Func<Order, bool>> expression = null)
        {

            func.Invoke(expression);
            throw new NotImplementedException();
        }

        public async Task<ReturnType> QueryAsync<T, ReturnType>(string methodName, Expression<Func<T, bool>> functionParameter, CancellationToken cancellationToken, int find = 0) where T : BaseEntity, new()
        {

            var EntityFrameworkQueryableExtensions = typeof(EntityFrameworkQueryableExtensions);
            var method = EntityFrameworkQueryableExtensions.GetMethods(BindingFlags.Static | BindingFlags.Public)
                     .FirstOrDefault(m => m.Name == methodName + "Async");

            var genericMethod = method.MakeGenericMethod(typeof(T));
            var query = Set<T>().AsQueryable();


            object[] parameters = new object[] { functionParameter == null ? query : query.Where(functionParameter), cancellationToken };


            var data = genericMethod.Invoke(null, parameters);

            if (data is Task<ReturnType> task)
            {
                return await task;
            }
            throw new NotImplementedException();
        }

        public async ValueTask<T> FindAsync<T>(params object[] keys) where T : BaseEntity, new()
        {
            return await Set<T>().FindAsync(keys);
        }

        public async Task<bool> ContainsAsync<T>(T data) where T : BaseEntity, new()
        {
          return await  Set<T>().ContainsAsync(data);
        }
    }
}
