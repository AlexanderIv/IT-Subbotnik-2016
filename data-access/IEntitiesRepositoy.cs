using System.Collections.Generic;
using System.Threading.Tasks;
using My.ToDoApp.Domain;

namespace My.ToDoApp.DataAccess {
    public interface IEntitiesRepository<T> where T: class, IEntity {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task SaveAsync(T entity);
        Task DeleteAsync(int id);
    }
}
