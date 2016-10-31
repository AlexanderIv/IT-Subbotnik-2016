using System;

namespace My.ToDoApp.Domain {
    public class UserTask: IEntity {
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime DueDate { get; set; }
        public UserTaskSeverity Severity { get; set; }
        public bool Done { get; set; }
        public User User { get; set; }
    }
}