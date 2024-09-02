using Domain;
using Domain.Common;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Common
{
    public interface IApplicationDbContext
    {
        //public IQueryable<User> User { get; }
        //public IQueryable<Order> Order { get; }

        public IQueryable<T> GetTable<T>(GetTableEnum getTableEnum) where T : BaseEntity, new();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<ReturnType> QueryAsync<T,ReturnType>(string methodName, Expression<Func<T, bool>> functionParameter, CancellationToken cancellationToken,int find=0)
        where T : BaseEntity,new();

        public void Test(Func<Expression<Func<Order, bool>>, Order> func, Expression<Func<Order, bool>> expression = null);

        public ValueTask<T> FindAsync<T>(params object[] keys) where T : BaseEntity, new();

        public Task<bool> ContainsAsync<T>(T data)where T : BaseEntity,new();
    }
}
