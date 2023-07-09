import { Component, OnInit } from '@angular/core';
import { User } from '../user'
import { UserService } from '../_service/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent {
  public users: User[] = [];

  constructor(private userService: UserService) {
    this.userService.getAll().subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}
