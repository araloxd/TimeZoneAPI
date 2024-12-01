public interface IGenericRepository<T>
{
    public Task<IEnumerable<T>> GetAllByIdAsync(Guid id);
    public Task<T?> GetByIdAsync(Guid id);
    public Task AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(Guid id);
}