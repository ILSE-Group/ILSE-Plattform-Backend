namespace Domain.IRepositories.IBaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T obj);
        Task DeleteAsync(Guid id);
        Task<T?> GetByIdAsync(Guid id);
        Task UpdateAsync(T obj);
        Task<List<T>> GetAllAsync();
    }
}
