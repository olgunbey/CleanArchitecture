using Application.Common;

namespace Persistance
{
    internal class CommandDbContext<T> : ICommandApplicationDbContext<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public CommandDbContext(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
