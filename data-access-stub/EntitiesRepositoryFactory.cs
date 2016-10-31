using System;
using System.Collections.Generic;
using My.ToDoApp.Domain;

namespace My.ToDoApp.DataAccess.Stubs {
    public class EntitiesRepositoryFactory : IEntitiesRepositoryFactory
    {
        private static readonly object SyncRoot = new object();
        private static readonly IDictionary<int, User> UsersById = new Dictionary<int, User>();
        private static readonly IDictionary<int, UserTask> UserTasksById = new Dictionary<int, UserTask>();

        static EntitiesRepositoryFactory() {
            int userId = 0;
            UsersById[++userId] = new User {
                Id = userId,
                Login = "sa",
                FirstName = "System",
                LastName = "Administrator",
                Email = "sa@corp.com",
                Tasks = new List<UserTask>()
            };
            UsersById[++userId] = new User {
                Id = userId,
                Login = "ai",
                FirstName = "Alexander",
                LastName = "Ivanov",
                Email = "ai@corp.com",
                Tasks = new List<UserTask>()
            };
            UsersById[++userId] = new User {
                Id = userId,
                Login = "joe",
                FirstName = "Doe",
                LastName = "John",
                Email = "joe@corp.com",
                Tasks = new List<UserTask>()
            };
            while(userId < 30) {
                UsersById[++userId] = new User {
                    Id = userId,
                    Login = "new" + userId,
                    FirstName = "New-" + userId,
                    LastName = "User-" + userId,
                    Email = $"joe-{userId}@corp.com",
                    Tasks = new List<UserTask>()
                };
            }


            int taskId = 0;
            UsersById[1].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Setup System",
                DueDate = DateTime.UtcNow.Date.AddDays(5).AddHours(10),
                Severity = UserTaskSeverity.High,
                Done = true
            });
            UsersById[1].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Upload data",
                DueDate = DateTime.UtcNow.Date.AddDays(5).AddHours(14),
                Severity = UserTaskSeverity.Normal,
                Done = true
            });
            UsersById[1].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Allow inbound connections",
                DueDate = DateTime.UtcNow.Date.AddDays(10).AddHours(9),
                Severity = UserTaskSeverity.Normal,
                Done = false
            });

            UsersById[2].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Drink Coffee",
                DueDate = DateTime.UtcNow.Date.AddDays(2).AddHours(10),
                Severity = UserTaskSeverity.Low,
                Done = false
            });
            UsersById[2].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Play football",
                DueDate = DateTime.UtcNow.Date.AddMonths(1).AddHours(19),
                Severity = UserTaskSeverity.Normal,
                Done = true
            });

            UsersById[3].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Watch TV",
                DueDate = DateTime.UtcNow.Date.AddHours(10),
                Severity = UserTaskSeverity.Low,
                Done = true
            });
            UsersById[3].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Ride bicycle",
                DueDate = DateTime.UtcNow.Date.AddDays(1).AddHours(15),
                Severity = UserTaskSeverity.Normal,
                Done = false
            });
            UsersById[3].AddTask(UserTasksById[++taskId] = new UserTask {
                Id = taskId,
                Action = "Have a lunch",
                DueDate = DateTime.UtcNow.Date.AddHours(14),
                Severity = UserTaskSeverity.High,
                Done = false
            });
        }
        
        public IEntitiesRepository<User> CreateUsersRepositoy()
        {
            return new EntitiesRepository<User>(UsersById);
        }

        public IEntitiesRepository<UserTask> CreateUserTasksRepository()
        {
            return new EntitiesRepository<UserTask>(UserTasksById);
        }
    }
}