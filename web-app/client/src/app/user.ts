export class User {
    id: number;

    constructor(
        public login: string, 
        public firstName: string,
        public lastName: string,
        public email: string
    ) { }
} 