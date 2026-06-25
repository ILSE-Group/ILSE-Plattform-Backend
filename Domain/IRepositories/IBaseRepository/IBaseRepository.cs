namespace Domain.IRepositories.IBaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T obj);
        Task DeleteAsync(Guid id);
        Task<T> UpdateAsync(T obj);
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
    }
}
