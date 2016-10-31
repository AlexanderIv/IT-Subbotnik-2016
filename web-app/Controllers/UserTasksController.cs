using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My.ToDoApp.DataAccess;
using My.ToDoApp.Domain;

namespace My.ToDoApp.WebApp {
    [Route("api/tasks")]
    [Route("api/users/{userId}/tasks")]
    public class UserTasksController {
        private readonly IEntitiesRepository<UserTask> tasksRepository;
        private readonly IEntitiesRepository<User> usersRepository;

        public UserTasksController(IEntitiesRepositoryFactory repositoryFactory) {
            tasksRepository = repositoryFactory.CreateUserTasksRepository();
            usersRepository = repositoryFactory.CreateUsersRepositoy();
        }

        [HttpGet]
        public async Task<ICollection> GetUserTasks(int userId) {
            User user = await usersRepository.GetAsync(userId).ConfigureAwait(false);
            return user.Tasks.Select(task => new {
                task.Id,
                task.Action,
                task.Severity,
                task.DueDate
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<object> Get(int id) {
            UserTask task = await tasksRepository.GetAsync(id).ConfigureAwait(false);
            return new {
                task.Id,
                task.Action,
                task.Severity,
                task.DueDate
            };
        }

        [HttpPost]
        public async Task<UserTask> Add(int userId, [FromBody] UserTask userTask) {
            User user = await usersRepository.GetAsync(userId).ConfigureAwait(false);
            user.AddTask(userTask);
            await tasksRepository.SaveAsync(userTask).ConfigureAwait(false);
            return userTask;
        }

        [HttpPut("{id}")]
        public async Task<UserTask> Update(int id, [FromBody] UserTask task) {
            task.Id = id;
            await tasksRepository.SaveAsync(task).ConfigureAwait(false);
            return task;
        }

        [HttpDelete("{id}")]
        public Task Delete(int id) {
            return tasksRepository.DeleteAsync(id);
        }
    }
}