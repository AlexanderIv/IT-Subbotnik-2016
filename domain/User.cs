using System.Collections.Generic;

namespace My.ToDoApp.Domain {
    public class User: IEntity {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<UserTask> Tasks { get; set; }

        public void AddTask(UserTask userTask) {
            Tasks.Add(userTask);
            userTask.User = this;
        }
    }
}
