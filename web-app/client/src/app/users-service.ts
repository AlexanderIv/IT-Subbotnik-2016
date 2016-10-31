import { Injectable } from '@angular/core'
import { Http, Response} from '@angular/http'
import { Observable } from 'rxjs/Observable'
import { ErrorObservable } from 'rxjs/Observable/ErrorObservable'

import { User } from './user'

@Injectable()
export class UsersService {
    private usersUrl: string = '/api/users/';

    constructor(private http: Http) { }

    getAll(): Promise<User[]> {
        return new Promise<User[]>((resolve, reject) => 
            this.http.get(this.usersUrl)
                .map((response: Response) => response.json() || [])
                .catch(this.handleError)
                .subscribe(users => resolve(users), err => reject(err)));
    }

    remove(user: User): Promise<{}> {
        return new Promise<{}>((resolve, reject) => 
            this.http.delete(this.usersUrl + user.id)
                .catch(this.handleError)
                .subscribe(() => resolve({}), err => reject(err)))
    }

    private handleError (error: any): ErrorObservable {
        let errMsg = (error.message) ? error.message :
        error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}