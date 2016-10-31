import { NgModule } from '@angular/core'
import { UniversalModule } from 'angular2-universal'

import { AppComponent } from './app.component'
import { UsersListComponent } from './users-list.component'
import { UsersService } from './users-service'

@NgModule({
    imports: [
        UniversalModule,
    ],
    declarations: [
        AppComponent,
        UsersListComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [ 
        UsersService 
    ]
})
export class AppModule { }