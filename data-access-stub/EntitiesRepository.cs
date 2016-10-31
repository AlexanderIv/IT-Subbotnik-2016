using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My.ToDoApp.Domain;

namespace My.ToDoApp.DataAccess.Stubs
{
    public class EntitiesRepository<T>: IEntitiesRepository<T> where T: class, IEntity
    {
        private int DELAY = 100;
        private readonly IDictionary<int, T> _entitiesById;

        public EntitiesRepository(IDictionary<int, T> entitiesById) {
            _entitiesById = entitiesById;
        }

        public async Task<T> GetAsync(int id)
        {
            await Task.Delay(DELAY).ConfigureAwait(false);
            T entity;
            return _entitiesById.TryGetValue(id, out entity) ? entity : null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            await Task.Delay(DELAY).ConfigureAwait(false);
            return _entitiesById.Values.ToList();
        }

        public async Task SaveAsync(T entity)
        {
            await Task.Delay(DELAY).ConfigureAwait(false);
            _entitiesById[entity.Id] = entity;
        }

        public async Task DeleteAsync(int id) {
            await Task.Delay(DELAY).ConfigureAwait(false);
            _entitiesById.Remove(id);
        }
    }
}
