namespace WatchMNS.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
