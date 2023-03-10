namespace LeaveManagement.Web.Contracts
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int id);
    }
}
