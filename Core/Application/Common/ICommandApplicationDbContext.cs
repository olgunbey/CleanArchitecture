namespace Application.Common
{
    public interface ICommandApplicationDbContext<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public T Remove(T entity);
        public T Update(T entity);
    }
}
