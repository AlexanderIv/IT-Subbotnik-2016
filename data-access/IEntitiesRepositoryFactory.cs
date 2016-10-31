using My.ToDoApp.Domain;

namespace My.ToDoApp.DataAccess {
    public interface IEntitiesRepositoryFactory {
        IEntitiesRepository<User> CreateUsersRepositoy();
        IEntitiesRepository<UserTask> CreateUserTasksRepository();
    }
}