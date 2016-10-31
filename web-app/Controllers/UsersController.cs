using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My.ToDoApp.DataAccess;
using My.ToDoApp.Domain;

namespace My.ToDoApp.WebApp {
    [Route("api/users")]
    public class UsersController: Controller {
        private readonly IEntitiesRepository<User> usersRepository;

        public UsersController(IEntitiesRepositoryFactory repositoryFactory) {
            usersRepository = repositoryFactory.CreateUsersRepositoy();
        }

        [HttpGet]
        public async Task<ICollection> ListAllAsync() {
            return (await usersRepository.GetAllAsync().ConfigureAwait(false))
                .Select(user => new {
                    user.Id,
                    user.Login,
                    user.FirstName,
                    user.LastName,
                    user.Email
                }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<object> GetAsync(int id) {
            User user = await usersRepository.GetAsync(id).ConfigureAwait(false);
            return new {    
                user.Id,
                user.Login,
                user.FirstName,
                user.LastName,
                user.Email
            };
        }

        [HttpPost]
        public async Task<User> CreateAsync([FromBody] User user) {
            user.Id = 0;
            await usersRepository.SaveAsync(user).ConfigureAwait(false);
            return user;
        }

        [HttpPut("{id}")]
        public async Task<User> Update(int id, [FromBody] User user) {
            user.Id = id;
            await usersRepository.SaveAsync(user).ConfigureAwait(false);
            return user;
        }

        [HttpDelete("{id}")]
        public Task Delete(int id) {
            return usersRepository.DeleteAsync(id);
        }
    }
}