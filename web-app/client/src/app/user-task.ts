export class UserTask {
    id: number;

    constructor(
        public userId: number,
        public action: string,
        public dueDate: Date,
        public severity: UserTaskSeverity,
        public done: boolean
    ) { }
}

export enum UserTaskSeverity {
    LOW,
    NORMAL,
    HIGH
}