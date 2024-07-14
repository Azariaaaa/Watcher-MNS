namespace WatchMNS.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        IQueryable<T> GetAll();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
