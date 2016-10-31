import { Component, OnInit } from '@angular/core'
import { User } from './user'
import { UsersService } from './users-service'

@Component({
    selector: 'users-list',
    templateUrl: './users-list.component.html'
})
export class UsersListComponent implements OnInit { 
    users: (User & Deletable)[] = [];
    loading: boolean;

    constructor(private usersService: UsersService) { }

    ngOnInit() {
        this.loading = true;
        this.usersService.getAll()
            .then(result => this.users = result)
            .then(result => {
                this.users.map(usr => usr.deleting = false);
                this.loading = false;
            });
    }

    refreshUsers() {
        this.loading = true;
        this.usersService.getAll()
            .then(result => this.users = result)
            .then(result => {
                this.users.map(usr => usr.deleting = false);
                this.loading = false;
            });
    }

    deleteUser(user: User & Deletable) {
        user.deleting = true;
        this.usersService.remove(user)
            .then(result => this.users.splice(this.users.findIndex(usr => usr.id == user.id), 1))
            .catch(err => user.deleting = false);
    }
}

interface Deletable {
    deleting?: boolean;
}
