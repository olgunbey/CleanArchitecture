using Domain.Entities;

namespace Application.Common
{
    public interface IApplicationDbContext
    {
        public IQueryable<User> User { get; }
        public IQueryable<Order> Order { get; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
